using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeAndBilling.Controllers.Common;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Interfaces;
using TimeAndBilling.Models.Repository;
using TimeAndBilling.ViewModels;

namespace TimeAndBilling.Controllers
{
    public class EmployeeController : EmployeeCommon
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeDetailRepository _employeeDetailRepository;
        private readonly IEmploymentDetailRepository _employmentDetailRepository;
        private readonly IEmployeeBankingRepository _employeeBankingRepository;


        public EmployeeController(IEmployeeRepository employeeRepository, 
            IEmployeeDetailRepository employeeDetailRepository, 
            IEmploymentDetailRepository employmentDetailRepository, 
            IEmployeeBankingRepository employeeBankingRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeDetailRepository = employeeDetailRepository;
            _employmentDetailRepository = employmentDetailRepository;
            _employeeBankingRepository = employeeBankingRepository;
        }


        public IActionResult List(String showInactive, String searchString)
        {
            IEnumerable<Employee> employees;

            bool isShowInactiveChecked = String.IsNullOrEmpty(showInactive) ? false : true;
            bool hasSearchString = String.IsNullOrEmpty(searchString) ? false : true; 

            if (!isShowInactiveChecked && hasSearchString)
            {
                var employeesByFirstName = _employeeRepository.GetEmployeeByFirstName(searchString.Trim()).Where(employee => employee.IsActive == true);
                var employeesByLastName = _employeeRepository.GetEmployeeByLastName(searchString.Trim()).Where(employee => employee.IsActive == true);

                employees = employeesByFirstName.Union(employeesByLastName);
                
                return View(new EmployeeViewModel{Employees = employees});
            }

            if (isShowInactiveChecked && !hasSearchString)
            {
                employees = _employeeRepository.GetAllEmployees;

                return View(new EmployeeViewModel{Employees = employees});
            }

            if(isShowInactiveChecked && hasSearchString){

                var employeesByFirstName = _employeeRepository.GetEmployeeByFirstName(searchString.Trim());
                var employeesByLastName = _employeeRepository.GetEmployeeByLastName(searchString.Trim());

                employees = employeesByFirstName.Union(employeesByLastName);

                return View(new EmployeeViewModel{Employees = employees});
            }

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
                //order is important here employeeRepository.DeleteEmployeeById must be last
                _employeeBankingRepository.DeleteEmployeeBankingInformation(id.Value);
                _employeeDetailRepository.DeleteEmployeeDetail(id.Value);
                _employmentDetailRepository.DeleteEmploymentDetail(id.Value);
                _employeeRepository.DeleteEmployeeById(id.Value);

                return RedirectToAction("List");
            }
        }
    }
}
