using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository.Interfaces
{
    public interface ITimeEntryRepository
    {
        IEnumerable<TimeEntry> GetAllTimeEntries { get;}

        TimeEntry AddNewTimeEntry(TimeEntry timeEntry);
        void DeleteTimeEntry(int? timeEntryID);
        TimeEntry UpdateTimeEntry(TimeEntry timeEntry);
        
    }
}
