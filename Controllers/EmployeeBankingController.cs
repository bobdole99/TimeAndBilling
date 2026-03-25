using Microsoft.AspNetCore.Mvc;
using System;
using TimeAndBilling.Controllers.Common;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Interfaces;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Controllers
{
    public class EmployeeBankingController : EmployeeCommon
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeBankingRepository _employeeBankingRepository;

        public EmployeeBankingController(IEmployeeBankingRepository employeeBankingRepository, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeBankingRepository = employeeBankingRepository;
        }

        public IActionResult Edit (int? id)
        {
            int employeeId = 0;
            if (id.HasValue)
            {
                employeeId = id.Value;
            }
            var employeeBankingInformation = _employeeBankingRepository.GetEmployeeBankingInformationById(employeeId);

            String fullName = GetEmployeeFullName(employeeId);

            if (employeeBankingInformation != null)
            {
                employeeBankingInformation.FullName = fullName;
                return View(employeeBankingInformation);
            }
            else
            {
                return View(new EmployeeBanking()
                {
                    FullName = fullName,
                    EmployeeID = employeeId
                });
            }
        }

        
        public IActionResult Save(EmployeeBanking employeeBanking)
        {
            var employeeBankingInformation = _employeeBankingRepository.GetEmployeeBankingInformationById(employeeBanking.EmployeeBankingID);
            if (employeeBankingInformation == null)
            {
                _employeeBankingRepository.AddEmployeeBankingInformation(employeeBanking);
            }
            else
            {
                _employeeBankingRepository.UpdateEmployeeBankingInformation(employeeBanking);
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
