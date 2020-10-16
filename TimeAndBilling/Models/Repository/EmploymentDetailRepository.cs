using System;
using System.Linq;
using TimeAndBilling.Models.Interfaces;

namespace TimeAndBilling.Models.Repository
{
    public class EmploymentDetailRepository : IEmploymentDetailRepository
    {
        private readonly AppDbContext _context;
        public EmploymentDetailRepository (AppDbContext context)
        {
            _context = context;
        }
        public EmploymentDetail AddEmploymentDetail(EmploymentDetail employmentDetail)
        {
            EmploymentDetail newEmploymentDetail = new EmploymentDetail
            {
                Contractor = employmentDetail.Contractor,
                Department = employmentDetail.Department,
                HourlyRate = employmentDetail.HourlyRate,
                JobTitle = employmentDetail.JobTitle,
                LeaveDate = employmentDetail.LeaveDate,  
                Manager = employmentDetail.Manager,
                Salary = employmentDetail.Salary,
                SSN = employmentDetail.SSN,
                StartDate = employmentDetail.StartDate,
                EmployeeID = employmentDetail.EmployeeID,
                EmployeeNumber = employmentDetail.EmployeeNumber,
                WorkEmail = employmentDetail.WorkEmail

            };

            _context.Add(newEmploymentDetail);
            _context.SaveChanges();

            return newEmploymentDetail;
        }

        public EmploymentDetail UpdateEmploymentDetail(EmploymentDetail employmentDetail)
        {
            var updateEmploymentDetail = _context.EmploymentDetails.FirstOrDefault(e => e.EmployeeID == employmentDetail.EmployeeID);
            
            updateEmploymentDetail.Contractor = employmentDetail.Contractor;
            updateEmploymentDetail.Department = employmentDetail.Department;
            updateEmploymentDetail.HourlyRate = employmentDetail.HourlyRate;
            updateEmploymentDetail.JobTitle = employmentDetail.JobTitle;
            updateEmploymentDetail.LeaveDate = employmentDetail.LeaveDate;
            updateEmploymentDetail.Manager = employmentDetail.Manager;
            updateEmploymentDetail.SSN = employmentDetail.SSN;
            updateEmploymentDetail.StartDate = employmentDetail.StartDate;
            updateEmploymentDetail.WorkEmail = employmentDetail.WorkEmail;
            updateEmploymentDetail.EmployeeNumber = employmentDetail.EmployeeNumber;

            _context.Update(updateEmploymentDetail);
            _context.SaveChanges();
            return null;
        }

        public EmploymentDetail GetEmploymentDetailById(int id)
        {
            var employmentDetail = _context.EmploymentDetails.FirstOrDefault(e => e.EmployeeID == id);
            return employmentDetail;
        }

        public void DeleteEmploymentDetail(int id)
        {
            var employmentDetail = _context.EmploymentDetails.FirstOrDefault(e => e.EmployeeID == id);
            if (employmentDetail != null)
            {
                _context.Remove(employmentDetail);
                _context.SaveChanges();
            }
        }
    }
}
