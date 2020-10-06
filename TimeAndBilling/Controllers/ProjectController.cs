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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Project project)
        {
            if (!ModelState.IsValid)
            {
                return View(project);
            }
            else
            {
                _projectRepository.AddNewProject(project);
            }

            return RedirectToAction("List");
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
            if (!id.HasValue)
            {
                return View();
            }
            else
            {
                var project = _projectRepository.GetProjectById(id.Value);
                return View(project);
            }
        }


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
