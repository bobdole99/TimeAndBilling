using Microsoft.AspNetCore.Mvc;
using System;
using TimeAndBilling.Controllers.Common;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Interfaces;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Controllers
{
    public class EmploymentDetailController : EmployeeCommon
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmploymentDetailRepository _employmentDetailRepository;

        public EmploymentDetailController(IEmploymentDetailRepository employmentDetailRepository, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employmentDetailRepository = employmentDetailRepository;
        }

        public IActionResult Edit (int? id)
        {
            int employeeId = 0;
            if (id.HasValue)
            {
                employeeId = id.Value;
            }
            var employmentDetail = _employmentDetailRepository.GetEmploymentDetailById(employeeId);

            String fullName = GetEmployeeFullName(employeeId);

            if (employmentDetail != null)
            {
                employmentDetail.FullName = fullName;
                return View(employmentDetail);
            }
            else
            {
                return View(new EmploymentDetail()
                {
                    FullName = fullName,
                    EmployeeID = employeeId
                });
            }
        }

        
        public IActionResult Save(EmploymentDetail employmentDetail)
        {
            var employmentDetails = _employmentDetailRepository.GetEmploymentDetailById(employmentDetail.EmploymentDetailID);
            if (employmentDetails == null)
            {
                _employmentDetailRepository.AddEmploymentDetail(employmentDetail);
            }
            else
            {
                _employmentDetailRepository.UpdateEmploymentDetail(employmentDetail);
            }
            return RedirectToAction("List", "Employee");
        }

        private String GetEmployeeFullName(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            String fullName = String.Empty;

            if (employee != null)
            {
                fullName = employee.FirstName + " " + employee.LastName;
            }
            return fullName;
        }
    }
}
