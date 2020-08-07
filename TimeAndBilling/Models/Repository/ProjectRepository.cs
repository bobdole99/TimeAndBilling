using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Project> GetAllProjects => _context.Projects;


        public Project AddNewProject(Project project)
        {
            Project newProject = new Project
            {
                ProjectCode = project.ProjectCode,
                ProjectDescription = project.ProjectDescription,
                ProjectName = project.ProjectName
            };

            _context.Add(newProject);
            _context.SaveChanges();

            return newProject;
        }

        public Project UpdateProject(Project project)
        {
            var updateProject = _context.Projects.FirstOrDefault(p => p.ProjectID == project.ProjectID);

            if (updateProject != null)
            {
                updateProject.ProjectCode = project.ProjectCode;
                updateProject.ProjectDescription = project.ProjectDescription;
                updateProject.ProjectName = project.ProjectName;
            }

            _context.Update(updateProject);
            _context.SaveChanges();

            return updateProject;
        }


        public Project DeleteProject(int? projectId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectID == projectId);

            _context.Remove(project);
            _context.SaveChanges();

            return project;
        }

        public Project GetProjectByCode(string code)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectCode == code);
            return project;
        }

        public Project GetProjectByName(string projectName)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectName == projectName);
            return project;
        }

        public Project GetProjectById(int? projectId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectID == projectId);
            return project;
        }

        public IEnumerable<SelectListItem> GetProjectsDropDown()
        {
            throw new NotImplementedException();
        }
    }
}
