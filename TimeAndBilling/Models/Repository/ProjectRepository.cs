﻿using Microsoft.AspNetCore.Mvc.Rendering;
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
                ProjectName = project.ProjectName,
                ProjectContactEmail = project.ProjectContactEmail,
                ProjectContactPhone = project.ProjectContactPhone,
                ActualProjectHours = project.ActualProjectHours,
                BillableHours = project.BillableHours,
                Completed = project.Completed,
                EstimatedProjectHours = project.EstimatedProjectHours,
                ProjectManager = project.ProjectManager,
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
                updateProject.ProjectManager = project.ProjectManager;
                updateProject.ProjectContactEmail = project.ProjectContactEmail;
                updateProject.ProjectContactPhone = project.ProjectContactPhone;
                updateProject.ActualProjectHours = project.ActualProjectHours;
                updateProject.BillableHours = project.BillableHours;
                updateProject.EstimatedProjectHours = project.EstimatedProjectHours;
                updateProject.Completed = project.Completed;
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

        public IEnumerable<Project> GetProjectsByCode(string code)
        {
                var projects = _context.Projects.Where(p => p.ProjectCode.Contains(code));
                return projects;   
        }

        public IEnumerable<Project> GetProjectsByName(string projectName)
        {
            var project = _context.Projects.Where(p => p.ProjectName.Contains(projectName));
            return null;
        }

        public Project GetProjectById(int? projectId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectID == projectId);
            return project;
        }
    }
}
