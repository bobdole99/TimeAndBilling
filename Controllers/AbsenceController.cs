using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Interfaces;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Controllers
{
    public class AbsenceController : Controller
    {
        private readonly IAbsenceRepository _absenceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public AbsenceController(IAbsenceRepository absenceRepository, IEmployeeRepository employeeRepository)
        {
            _absenceRepository = absenceRepository;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            PopulateEmployeesDropDown();
            Absence absence = new Absence();
            absence.StartDate = DateTime.Today;
            absence.EndDate = DateTime.Today.AddDays(1);

            return View(absence);
        }

        public IActionResult Add(Absence absence)
        {
            PopulateEmployeesDropDown(absence.EmployeeID);
            if (!ModelState.IsValid)
            {
                return View(absence);
            }
            else
            {
                _absenceRepository.AddAbsence(absence);
            }
            return View();
        }

        private void PopulateEmployeesDropDown(object selectedEmployee = null)
        {
            var employees = from e in _employeeRepository.GetAllEmployees
                            orderby e.FirstName
                            select e;
            ViewBag.EmployeeID = new SelectList(employees, "EmployeeID", "FirstName", selectedEmployee);
        }
    }
}
