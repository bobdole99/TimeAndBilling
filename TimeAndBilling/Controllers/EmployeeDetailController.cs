﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
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
                return View(new EmployeeDetail()  { 
                    FullName = fullName,
                    EmployeeID = employeeId
                });
            }
        }

        public IActionResult Save(EmployeeDetail employeeDetail)
        {
            //potentially change this later to get the employee detail first
            //check if exists first, if it doesn't add new if it does update existing
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
            String fullName = String.Empty;
            if (employee != null)
            {
                fullName = employee.FirstName + " " + employee.LastName;
            }
            return fullName;
        }
    }
}
