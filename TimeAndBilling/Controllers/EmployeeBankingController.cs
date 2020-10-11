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
    public class EmployeeBankingController : Controller
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
            var employeeDetail = _employeeBankingRepository.GetEmployeeBankingInformationById(employeeId);

            String fullName = GetEmployeeFullName(employeeId);

            if (employeeDetail != null)
            {
                employeeDetail.FullName = fullName;
                return View(employeeDetail);
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
            //potentially change this later to get the employment detail first
            //check if exists first, if it doesn't add new if it does update existing
            if (employeeBanking.EmployeeBankingID == 0)
            {
                _employeeBankingRepository.AddEmployeeBankingInformation(employeeBanking);
            }
            else if (employeeBanking.EmployeeBankingID > 0)
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
