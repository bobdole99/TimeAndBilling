using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Repository;
using TimeAndBilling.ViewModels;

namespace TimeAndBilling.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult List()
        {
            IEnumerable<Employee> employees;

            employees = _employeeRepository.GetAllEmployees;

            return View(new EmployeeViewModel
            {
                Employees = employees
            });
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
