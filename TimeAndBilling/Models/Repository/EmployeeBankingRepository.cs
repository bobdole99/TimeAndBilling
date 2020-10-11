using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models.Interfaces;

namespace TimeAndBilling.Models.Repository
{
    public class EmployeeBankingRepository : IEmployeeBankingRepository
    {

        private readonly AppDbContext _context;
        public EmployeeBankingRepository (AppDbContext context)
        {
            _context = context;
        }

        public EmployeeBanking AddEmployeeBankingInformation(EmployeeBanking employeeBanking)
        {
            EmployeeBanking newEmployeeBanking = new EmployeeBanking
            {
                AccountNumber = employeeBanking.AccountNumber,
                City = employeeBanking.City,
                InstituteNumber = employeeBanking.InstituteNumber,
                NameOfBank = employeeBanking.NameOfBank,
                PostalCode = employeeBanking.PostalCode,
                Province = employeeBanking.Province,
                TransitNumber = employeeBanking.TransitNumber
            };
            _context.Add(newEmployeeBanking);
            _context.SaveChanges();

            return newEmployeeBanking;
        }

        public EmployeeBanking UpdateEmployeeBankingInformation(EmployeeBanking employeeBanking)
        {
            var employeeBankingInformation = _context.EmployeeBankings.FirstOrDefault(e => e.EmployeeID == employeeBanking.EmployeeID);

            employeeBanking.AccountNumber = employeeBanking.AccountNumber;
            employeeBanking.City = employeeBanking.City;
            employeeBanking.InstituteNumber = employeeBanking.InstituteNumber;
            employeeBanking.NameOfBank = employeeBanking.NameOfBank;
            employeeBanking.PostalCode = employeeBanking.PostalCode;
            employeeBanking.Province = employeeBanking.Province;
            employeeBanking.TransitNumber = employeeBanking.TransitNumber;

            _context.Update(employeeBanking);
            _context.SaveChanges();

            return employeeBanking;
        }

        public EmployeeBanking GetEmployeeBankingInformationById(int id)
        {
            var employeeBankingInformation = _context.EmployeeBankings.FirstOrDefault(e => e.EmployeeID == id);
            return employeeBankingInformation;
        }
    }
}
