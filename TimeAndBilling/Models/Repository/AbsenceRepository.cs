using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models.Interfaces;

namespace TimeAndBilling.Models.Repository
{
    public class AbsenceRepository : IAbsenceRepository
    {
        private readonly AppDbContext _context;

        public AbsenceRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Absence> GetAllAbsences => _context.Absences;

        public Absence AddAbsence(Absence absence)
        {
            Absence newAbsence = new Absence
            {
                StartDate = absence.StartDate,
                EndDate = absence.EndDate,
                Employee = absence.Employee,
                Reason = absence.Reason,
                EmployeeID = absence.EmployeeID
            };

            _context.Add(newAbsence);
            _context.SaveChanges();

            return newAbsence;
        }

        public IEnumerable<Absence> GetAbsencesByDateRange(DateTime startDate, DateTime endDate)
        {

            IEnumerable<Absence> absencesByDateRange = 
                _context.Absences.Where(a => a.StartDate >= startDate && a.EndDate <= endDate);
            return absencesByDateRange;
        }

        public IEnumerable<Absence> GetAbsencesByEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
