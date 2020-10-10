using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Interfaces;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Controllers
{
    public class EmploymentDetailController : Controller
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
            var employeeDetail = _employmentDetailRepository.GetEmploymentDetailById(employeeId);

            String fullName = GetEmployeeFullName(employeeId);

            if (employeeDetail != null)
            {
                employeeDetail.FullName = fullName;
                return View(employeeDetail);
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
            //potentially change this later to get the employment detail first
            //check if exists first, if it doesn't add new if it does update existing
            if (employmentDetail.EmploymentDetailID == 0)
            {
                _employmentDetailRepository.AddEmploymentDetail(employmentDetail);
            }
            else if (employmentDetail.EmploymentDetailID > 0)
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
