using System.Linq;
using TimeAndBilling.Models.Interfaces;

namespace TimeAndBilling.Models.Repository
{
    public class EmployeeDetailRepository : IEmployeeDetailRepository
    {
        private readonly AppDbContext _context;

        public EmployeeDetailRepository(AppDbContext context)
        {
            _context = context;
        }
        public EmployeeDetail GetEmployeeDetailById(int id) {
            var employmentDetail  = 
                _context.EmployeeDetails.FirstOrDefault(e => e.EmployeeID.EmployeeID == id);
            return employmentDetail;
        }
    }
}
