using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository.Interfaces
{
    public interface ITimeEntryRepository
    {
        IEnumerable<TimeEntry> GetAllTimeEntries { get; set; }
        IEnumerable<TimeEntry> GetTimeEntriesByEmployeeId(int id);
        IEnumerable<TimeEntry> GetTimeEntriesByDateRange(DateTime start, DateTime end);
        
    }
}
