using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace TimeAndBilling.Models.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees { get; }

        IEnumerable<Employee> GetEmployeeByLastName(String searchString);
        IEnumerable<Employee> GetEmployeeByFirstName(String searchString);
        Employee GetEmployeeById(int employeeId);

        Employee DeleteEmployeeById(int employeeId);

        Employee AddNewEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);

        IEnumerable<SelectListItem> GetEmployeeDropDown();
    }
}
