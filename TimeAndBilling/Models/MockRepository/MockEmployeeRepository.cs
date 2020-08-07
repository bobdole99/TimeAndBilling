using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Models.MockRepository
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees => new List<Employee>
        {
            new Employee {FirstName = "Jeff", LastName ="Jameson", MiddleName = "", EmployeeID = 1 },
            new Employee {FirstName = "Jane", LastName = "McCabe", MiddleName="Sarah", EmployeeID = 2},
            new Employee {FirstName = "Travis", LastName ="Oswald", MiddleName ="John", EmployeeID = 3 },
            new Employee {FirstName = "Sarah", LastName = "Freddy", MiddleName = "", EmployeeID = 4 }
        };

        public Employee AddNewEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }


        //Function not working correctly.
        public Employee DeleteEmployeeById(int employeeId)
        {
            Employee employees = new Employee();
            
            foreach(var item in GetAllEmployees)
            {
                if(item.EmployeeID != employeeId)
                {
                    employees = item;
                }
            }
            return employees;
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return GetAllEmployees.FirstOrDefault(e => e.EmployeeID == employeeId);
        }

        public IEnumerable<SelectListItem> GetEmployeeDropDown()
        {
            throw new NotImplementedException();
        }
    }
}