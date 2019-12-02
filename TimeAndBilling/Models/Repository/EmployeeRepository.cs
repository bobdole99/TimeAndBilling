using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository (AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetAllEmployees => _context.Employees;

        public Employee GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
