using System;
using System.Collections.Generic;
using System.Linq;
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



        public IActionResult List()
        {
            IEnumerable<Project> projects;
            projects = _projectRepository.GetAllProjects;

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
    }
}
