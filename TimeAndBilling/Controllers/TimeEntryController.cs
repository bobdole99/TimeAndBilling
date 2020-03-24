using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Repository;
using TimeAndBilling.Models.Repository.Interfaces;
using TimeAndBilling.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeAndBilling.Controllers
{
    public class TimeEntryController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeEntryRepository _timeEntryRepository;

        public TimeEntryController(IProjectRepository projectRepository, IEmployeeRepository employeeRepository, ITimeEntryRepository timeEntryRepository)
        {
            _employeeRepository = employeeRepository;
            _projectRepository = projectRepository;
            _timeEntryRepository = timeEntryRepository;
        }

        public IActionResult Index()
        {
            var projects = _projectRepository.GetProjectsDropDown();
            var employees = _employeeRepository.GetEmployeeDropDown();
            var timeEntries = _timeEntryRepository.GetAllTimeEntries;

            return View(new TimeEntryViewModel
            {
                Employees = employees,
                Projects = projects,
                TimeEntries = timeEntries
               
            });
        }

        public ActionResult Add(TimeEntry timeEntry)
        {
            if (!ModelState.IsValid)
            {
                return View(timeEntry);
            }
            else
            {
                _timeEntryRepository.AddNewTimeEntry(timeEntry);
            }
            return RedirectToAction("Index");
        }
    }
}
