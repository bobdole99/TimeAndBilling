using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Models.MockRepository
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees => new List<Employee>
        {
            new Employee {FirstName = "Jeff", LastName ="Jameson", MiddleName = "", DateOfBirth= new DateTime(1989, 11, 24), Id = 1 },
            new Employee {FirstName = "Jane", LastName = "McCabe", MiddleName="Sarah", DateOfBirth = new DateTime(1976, 12, 5), Id = 2},
            new Employee {FirstName = "Travis", LastName ="Oswald", MiddleName ="John", DateOfBirth = new DateTime(1983, 1, 6), Id = 3 },
            new Employee {FirstName = "Sarah", LastName = "Freddy", MiddleName = "", DateOfBirth = new DateTime(1992, 4, 16), Id = 4 }
        };

        public Employee GetEmployeeById(int employeeId)
        {
            return GetAllEmployees.FirstOrDefault(e => e.Id == employeeId);
        }
    }
}