using Microsoft.AspNetCore.Mvc;
using System;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Interfaces;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Controllers
{
    public class EmployeeDetailController : Controller
    {
        private readonly IEmployeeDetailRepository _employeeDetailRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeDetailController(IEmployeeDetailRepository employeeDetailRepository, IEmployeeRepository employeeRepository)
        {
            _employeeDetailRepository = employeeDetailRepository;
            _employeeRepository = employeeRepository;
        }

        public IActionResult Edit(int? id)
        {
            int employeeId = 0; 
            if (id.HasValue)
            {
                employeeId = id.Value;
            }
            var employeeDetail = _employeeDetailRepository.GetEmployeeDetailById(employeeId);
            String fullName = GetEmployeeFullName(employeeId);

            if (employeeDetail != null)
            {
                employeeDetail.FullName = fullName;
                return View(employeeDetail);
            }
            else
            {
                return View(new EmployeeDetail() { FullName = fullName });
            }
        }

        public IActionResult Save(EmployeeDetail employeeDetail)
        {
            if (employeeDetail.EmployeeDetailID == 0)
            {
                _employeeDetailRepository.AddEmployeeDetail(employeeDetail);
            }
            else if (employeeDetail.EmployeeDetailID > 0)
            {
                _employeeDetailRepository.UpdateEmployeeDetail(employeeDetail);
            }
            return RedirectToAction("List", "Employee");
        }

        public String GetEmployeeFullName(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            return employee.FirstName + ", " + employee.LastName;
        }
    }
}
