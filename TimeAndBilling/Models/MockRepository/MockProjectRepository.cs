using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Models.MockRepository
{
    public class MockProjectRepository : IProjectRepository
    {
        private IEnumerable<Project> ProjectList = new List<Project>
            {
            new Project { ProjectName ="Time and Billing", ProjectCode = "TandB", ProjectDescription = "A time and billing application demonstrating MVVC", ProjectID= 1},
            new Project {ProjectName = "Backend Enhancements", ProjectCode = "BE01", ProjectDescription = "Numerous changes to the back end architecture", ProjectID = 2},
            new Project {ProjectName = "Frontend Enhancements", ProjectCode = "FE01", ProjectDescription = "Changes to the interface", ProjectID = 3}
            };

        IEnumerable<Project> IProjectRepository.GetAllProjects => ProjectList;

        public Project AddNewProject(Project project)
        {
            Project newProject = new Project();

            if (project == null)
            {
                newProject.ProjectName = project.ProjectName;
                newProject.ProjectCode = project.ProjectCode;
                newProject.ProjectDescription = project.ProjectDescription;
            }
            ProjectList.Append(newProject);

            return newProject;
        }

        public Project DeleteProject(int? projectId)
        {
            var itemToDelete = ProjectList.FirstOrDefault(p => p.ProjectID == projectId.Value);
            ProjectList = ProjectList.Where(p => p.ProjectID != projectId.Value);
            return itemToDelete;

        }

        public Project UpdateProject(Project project)
        {
            var itemToUpdate = ProjectList.Where(p => p.ProjectID == project.ProjectID);

            foreach (Project p in itemToUpdate)
            {
                p.ProjectCode = project.ProjectCode;
                p.ProjectDescription = project.ProjectDescription;
                p.ProjectName = project.ProjectName;
            }

            return itemToUpdate.FirstOrDefault();
        }


        public Project GetProjectByCode(string code)
        {
            return ProjectList.FirstOrDefault(e => e.ProjectCode == code);
        }

        public Project GetProjectById(int? projectId)
        {
            return ProjectList.FirstOrDefault(e => e.ProjectID == projectId.Value);
        }

        public Project GetProjectByName(string name)
        {
            return ProjectList.FirstOrDefault(e => e.ProjectName == name);
        }

        public IEnumerable<SelectListItem> GetProjectsDropDown()
        {
            throw new NotImplementedException();
        }


    }
}
