using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Repository;
using TimeAndBilling.Models.Repository.Interfaces;
using System.Linq;
using TimeAndBilling.ViewModels;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace TimeAndBilling.Controllers
{
    public class TimeEntryController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeEntryRepository _timeEntryRepository;

        public TimeEntryController(IProjectRepository projectRepository,
                                    IEmployeeRepository employeeRepository,
                                    ITimeEntryRepository timeEntryRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _timeEntryRepository = timeEntryRepository;
        }

        public IActionResult List()
        {
            IEnumerable<TimeEntry> timeEntries = _timeEntryRepository.GetAllTimeEntries;

            ViewBag.Date = DateTime.Today;

            return View(new TimeEntryViewModel
            {
                TimeEntries = timeEntries
            });

        }

        public IActionResult Delete()
        {
            return null;
        }

        public IActionResult Edit()
        {
            return null;
        }

        public IActionResult Add()
        {
            PopulateEmployeeDropDown();
            PopulateProjectDropDown();
            return View();
        }

        [HttpPost]
        public IActionResult Add(TimeEntry timeEntry)
        {
            if (!ModelState.IsValid)
            {
                return View(timeEntry);
            }
            else
            {
                _timeEntryRepository.AddNewTimeEntry(timeEntry);
            }

            return RedirectToAction("List");
        }

        private void PopulateProjectDropDown(object selectedProject = null)
        {
            var projects = from p in _projectRepository.GetAllProjects
                           orderby p.ProjectName
                           select p;
            ViewBag.ProjectID = new SelectList(projects, "ProjectID", "ProjectName", selectedProject);
        }

        private void PopulateEmployeeDropDown(object selectedEmployee = null)
        {
            var employees = from e in _employeeRepository.GetAllEmployees
                            orderby e.FirstName
                            select e;
            ViewBag.EmployeeID = new SelectList(employees, "EmployeeID", "FirstName", selectedEmployee);
        }
    }
}
