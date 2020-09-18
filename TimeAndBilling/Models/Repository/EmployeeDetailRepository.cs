using Microsoft.AspNetCore.DataProtection;
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
                Country = employeeDetail.Country
            };
            _context.Add(newDetail);
            _context.SaveChanges();

            return newDetail;
        }

        public EmployeeDetail GetEmployeeDetailById(int id)
        {
            var employmentDetail =
                _context.EmployeeDetails.FirstOrDefault(e => e.Employee.EmployeeID == id);
            return employmentDetail;
        }

        public EmployeeDetail UpdateEmployeeDetail(EmployeeDetail employeeDetail)
        {
            var updateEmployeeDetails = _context.EmployeeDetails.FirstOrDefault
                (e => e.EmployeeDetailID == employeeDetail.EmployeeDetailID);

            updateEmployeeDetails.Address = employeeDetail.Address;
            updateEmployeeDetails.AlternatePhoneNumber = employeeDetail.AlternatePhoneNumber;
            updateEmployeeDetails.City = employeeDetail.City;
            updateEmployeeDetails.Country = employeeDetail.Country;
            updateEmployeeDetails.DateOfBirth = employeeDetail.DateOfBirth;
            updateEmployeeDetails.EmergencyPhoneNumber = employeeDetail.EmergencyPhoneNumber;
            updateEmployeeDetails.PhoneNumber = employeeDetail.PhoneNumber;
            updateEmployeeDetails.PostalCode = employeeDetail.PostalCode;
            updateEmployeeDetails.ProvinceState = employeeDetail.ProvinceState;

            _context.Update(updateEmployeeDetails);
            _context.SaveChanges();

            return updateEmployeeDetails;
        }
    }
}
