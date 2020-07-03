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

        public IActionResult Edit(int? id)
        {

            if (!id.HasValue)
            {
                return View();
            }
            else
            {
                var employee = _employeeRepository.GetEmployeeById(id.Value);
                return View(employee);
            }
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            else
            {
                _employeeRepository.AddNewEmployee(employee);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Update(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            else
            {
                _employeeRepository.UpdateEmployee(employee);
            }
            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return View();
            }
            else
            {
                _employeeRepository.DeleteEmployeeById(id.Value);
                return RedirectToAction("List");
            }
        }
    }
}
