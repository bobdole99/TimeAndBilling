using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees => _context.Employees;


        public Employee AddNewEmployee(Employee employee)
        {

            Employee newEmployee = new Employee
            {
                FirstName = employee.FirstName,
                IsActive = employee.IsActive,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName
            };

            _context.Add(newEmployee);
            _context.SaveChanges();

            return newEmployee;
        }


        public Employee DeleteEmployeeById(int employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            _context.Remove(employee);
            _context.SaveChanges();

            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var updateEmployee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);

            updateEmployee.FirstName = employee.FirstName;
            updateEmployee.IsActive = employee.IsActive;
            updateEmployee.LastName = employee.LastName;
            updateEmployee.MiddleName = employee.MiddleName;

            _context.Update(updateEmployee);
            _context.SaveChanges();

            return updateEmployee;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
            return employee;
        }


        public IEnumerable<SelectListItem> GetEmployeeDropDown()
        {
            List<SelectListItem> countries = _context.Employees
                .OrderBy(n => n.FirstName)
                    .Select(n =>
                    new SelectListItem
                    {
                        Value = n.EmployeeID.ToString(),
                        Text = n.FirstName
                    }).ToList();


            var projectTip = new SelectListItem()
            {
                Value = null,
                Text = "--- Select Employee ---"
            };
            countries.Insert(0, projectTip);
            return new SelectList(countries, "Value", "Text");
        }
    }
}
