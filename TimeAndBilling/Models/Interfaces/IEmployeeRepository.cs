﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees { get; }
        Employee GetEmployeeById(int employeeId);

        Employee DeleteEmployeeById(int employeeId);

        Employee AddNewEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);
    }
}