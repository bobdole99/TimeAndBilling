using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models.Interfaces;

namespace TimeAndBilling.Models.MockRepository
{
    public class MockAbsenceRepository : IAbsenceRepository
    {
        public IEnumerable<Absence> GetAllAbsences => throw new NotImplementedException();

        public Absence AddAbsence(Absence absence)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Absence> GetAbsencesByDateRange(DateTime startDate, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Absence> GetAbsencesByEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
