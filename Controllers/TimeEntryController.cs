using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Repository;
using TimeAndBilling.Models.Repository.Interfaces;
using System.Linq;
using TimeAndBilling.ViewModels;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace TimeAndBilling.Controllers
{
    public class TimeEntryController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ITimeEntryRepository _timeEntryRepository;

        public TimeEntryController(IProjectRepository projectRepository, ITimeEntryRepository timeEntryRepository)
        {
            _projectRepository = projectRepository;
            _timeEntryRepository = timeEntryRepository;
        }

        public IActionResult List()
        {
            IEnumerable<TimeEntry> timeEntries = _timeEntryRepository.GetAllTimeEntries;
            PopulateProjectDropDown();

            ViewBag.Date = DateTime.Today;
            TimeEntry timeEntry = new TimeEntry();
            timeEntry.Date = DateTime.Today;

            ViewBag.NumberOfHours = GetNumberOfHours();

            return View(new TimeEntryViewModel
            {
                TimeEntries = timeEntries,
                TimeEntry = timeEntry
            });

        }

        public IActionResult Delete(int? timeEntryID)
        {
            var entry = _timeEntryRepository.GetAllTimeEntries.FirstOrDefault(t => t.TimeEntryID == timeEntryID);
            if (entry != null)
            {
                _timeEntryRepository.DeleteTimeEntry(entry.TimeEntryID);
            }
            return RedirectToAction("List");
        }


        public IActionResult Save(TimeEntry timeEntry)
        {
            if (timeEntry != null)
            {
                _timeEntryRepository.UpdateTimeEntry(timeEntry);
            }
            return RedirectToAction("List");
        }


        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var timeEntry = _timeEntryRepository.GetAllTimeEntries.FirstOrDefault(t => t.TimeEntryID == id);
                PopulateProjectDropDown(timeEntry.ProjectID);
                return View(timeEntry);
            }
            else
            {
                return RedirectToAction("List");
            }
        }


        //NOTE: When adding a new time entry the employee ID is for now hard coded to 1
        [HttpPost]
        public IActionResult Add(TimeEntryViewModel timeEntryViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(timeEntryViewModel);
            }
            else
            {
                //Remove this hard coded employee ID to the employee ID that is logged in
                //Leave this change for later
                timeEntryViewModel.TimeEntry.EmployeeID = 1;
                _timeEntryRepository.AddNewTimeEntry(timeEntryViewModel.TimeEntry);
            }
            PopulateProjectDropDown();
            return RedirectToAction("List");
        }

        private void PopulateProjectDropDown(object selectedProject = null)
        {
            var projects = from p in _projectRepository.GetAllProjects
                           orderby p.ProjectName
                           select p;
            ViewBag.ProjectID = new SelectList(projects, "ProjectID", "ProjectName", selectedProject);
        }

        //Update this later to only show for user logged in
        //add number of work hours in config rather than hard coding it to 8
        private decimal GetNumberOfHours()
        {
            var timeEntries = _timeEntryRepository.GetAllTimeEntries
                .Where(te => te.Date >= DateTime.Today && te.Date <= DateTime.Today.AddDays(1))
                .Sum(te => te.Hours);
            return timeEntries;
        }
    }
}