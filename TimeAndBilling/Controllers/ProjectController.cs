using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Repository;
using TimeAndBilling.ViewModels;

namespace TimeAndBilling.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }


        public IActionResult Update(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            else
            {
                _projectRepository.UpdateProject(project);
            }
            return RedirectToAction("List");
        }

        public IActionResult Edit(int? id)
        {
            var project = _projectRepository.GetProjectById(id);
            if (project == null)
            {
                return View(new Project());
            }
            else
            {
                return View(project);
            }
        }


        // TODO: Remove the Project View Model for this and just pass the the emuerable into the list view
        //Use a Project view model for the edit page
        public IActionResult List(string searchString)
        {
            IEnumerable<Project> projects;

            if (!String.IsNullOrEmpty(searchString))
            {
                projects = Search(searchString);
                if(projects.Count() == 0)
                {
                    ViewBag.SearchResults = "No search results for: \"" + searchString + "\""; 
                }
            }
            else
            {
                projects = _projectRepository.GetAllProjects;
                if (projects.Count() == 0)
                {
                    ViewBag.SearchResults = "No data present in database";
                }
            }

            return View(new ProjectViewModel
            {
                Projects = projects
            });
        }


        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return View();
            }
            else
            {
                _projectRepository.DeleteProject(id);
            }
            return RedirectToAction("List");
        }

        public IEnumerable<Project> Search(string searchString)
        {
            string cleanedSearchString = searchString.Trim();

            var projectsByCode = _projectRepository.GetProjectsByCode(cleanedSearchString);
            var projectsByName = _projectRepository.GetProjectsByName(cleanedSearchString);

            if (projectsByName != null && projectsByCode != null)
                return projectsByCode.Union(projectsByName);
            else if (projectsByName == null)
                return projectsByCode;
            else if (projectsByCode == null)
                return projectsByName;
            else
                return Enumerable.Empty<Project>();
        }
    }
}
