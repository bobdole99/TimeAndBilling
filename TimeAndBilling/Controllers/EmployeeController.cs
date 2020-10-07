using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public IActionResult List(String showInactive, String searchString)
        {
            IEnumerable<Employee> employees;

            bool isShowInactiveChecked = String.IsNullOrEmpty(showInactive) ? false : true;
            bool hasSearchString = String.IsNullOrEmpty(searchString) ? false : true; 

            //show inactive not checked but a search string is provided
            if (!isShowInactiveChecked && hasSearchString)
            {
                var employeesByFirstName = _employeeRepository
                    .GetEmployeeByFirstName(searchString.Trim())
                    .Where(employee => employee.IsActive == true);

                var employeesByLastName = _employeeRepository
                    .GetEmployeeByLastName(searchString.Trim())
                    .Where(employee => employee.IsActive == true);

                employees = employeesByFirstName.Union(employeesByLastName);
                
                return View(new EmployeeViewModel{Employees = employees});
            }

            //show inactive checked but no search string provided
            if (isShowInactiveChecked && !hasSearchString)
            {
                employees = _employeeRepository.GetAllEmployees;

                return View(new EmployeeViewModel{Employees = employees});
            }

            //show inactive checkbox and a search string is entered
            if(isShowInactiveChecked && hasSearchString){

                var employeesByFirstName = _employeeRepository.GetEmployeeByFirstName(searchString.Trim());
                var employeesByLastName = _employeeRepository.GetEmployeeByLastName(searchString.Trim());

                employees = employeesByFirstName.Union(employeesByLastName);

                return View(new EmployeeViewModel{Employees = employees});
            }

            //By default return all active employees
            employees = _employeeRepository.GetAllEmployees.Where(employee => employee.IsActive == true);
            return View(new EmployeeViewModel{Employees = employees});
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
