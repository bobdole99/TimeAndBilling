using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects { get;  }

        IEnumerable<Project> GetProjectsByName(string name);
        IEnumerable<Project> GetProjectsByCode(string code);

        Project GetProjectById(int? projectId);

        public Project AddNewProject(Project project);
        public Project DeleteProject(int? projectId);
        public Project UpdateProject(Project project);
        IEnumerable<SelectListItem> GetProjectsDropDown();

    }
}
