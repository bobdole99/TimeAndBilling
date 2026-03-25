using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Interfaces
{
    public interface IAbsenceRepository
    {
        IEnumerable<Absence> GetAllAbsences { get; }
        IEnumerable<Absence> GetAbsencesByDateRange(DateTime startDate, DateTime dateTime);
        IEnumerable<Absence> GetAbsencesByEmployee(Employee employee);

        Absence AddAbsence(Absence absence);

    }
}
