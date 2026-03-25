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

        public EmployeeDetail AddEmployeeDetail(EmployeeDetail employeeDetail)
        {
            EmployeeDetail newDetail = new EmployeeDetail
            {
                DateOfBirth = employeeDetail.DateOfBirth,
                Address = employeeDetail.Address,
                PostalCode = employeeDetail.PostalCode,
                PhoneNumber = employeeDetail.PhoneNumber,
                AlternatePhoneNumber = employeeDetail.AlternatePhoneNumber,
                EmergencyPhoneNumber = employeeDetail.EmergencyPhoneNumber,
                City = employeeDetail.City,
                ProvinceState = employeeDetail.ProvinceState,
                Country = employeeDetail.Country,
                EmployeeID = employeeDetail.EmployeeID,
                Gender = employeeDetail.Gender,
                MaritalStatus = employeeDetail.MaritalStatus,
                Nationality = employeeDetail.Nationality
            };
            _context.Add(newDetail);
            _context.SaveChanges();

            return newDetail;
        }

        public EmployeeDetail GetEmployeeDetailById(int id)
        {
            var employeeDetail =
                _context.EmployeeDetails.FirstOrDefault(e => e.Employee.EmployeeID == id);
            return employeeDetail;
        }

        public EmployeeDetail UpdateEmployeeDetail(EmployeeDetail employeeDetail)
        {
            var updateEmployeeDetails = _context.EmployeeDetails.FirstOrDefault(e => e.EmployeeDetailID == employeeDetail.EmployeeDetailID);

            updateEmployeeDetails.Address = employeeDetail.Address;
            updateEmployeeDetails.AlternatePhoneNumber = employeeDetail.AlternatePhoneNumber;
            updateEmployeeDetails.City = employeeDetail.City;
            updateEmployeeDetails.Country = employeeDetail.Country;
            updateEmployeeDetails.DateOfBirth = employeeDetail.DateOfBirth;
            updateEmployeeDetails.EmergencyPhoneNumber = employeeDetail.EmergencyPhoneNumber;
            updateEmployeeDetails.PhoneNumber = employeeDetail.PhoneNumber;
            updateEmployeeDetails.PostalCode = employeeDetail.PostalCode;
            updateEmployeeDetails.ProvinceState = employeeDetail.ProvinceState;
            updateEmployeeDetails.Gender = employeeDetail.Gender;
            updateEmployeeDetails.MaritalStatus = employeeDetail.MaritalStatus;
            updateEmployeeDetails.Nationality = employeeDetail.Nationality;

            _context.Update(updateEmployeeDetails);
            _context.SaveChanges();

            return updateEmployeeDetails;
        }

        public void DeleteEmployeeDetail(int id)
        {
            var employeeDetails = _context.EmployeeDetails.FirstOrDefault(e => e.EmployeeDetailID == id);
            if(employeeDetails != null)
            {
                _context.Remove(employeeDetails);
                _context.SaveChanges();
            }
        }
    }
}