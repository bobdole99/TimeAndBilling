using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models.Repository.Interfaces;

namespace TimeAndBilling.Models.MockRepository
{
    public class MockTimeEntryRepository : ITimeEntryRepository
    {
        public IEnumerable<TimeEntry> GetAllTimeEntries { get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); }

        public TimeEntry AddNewTimeEntry(TimeEntry timeEntry)
        {
            throw new NotImplementedException();
        }

        public TimeEntry DeleteTimeEntry(TimeEntry timeEntry)
        {
            throw new NotImplementedException();
        }
    }
}
