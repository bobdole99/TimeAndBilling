using System;
using System.Collections.Generic;
using System.Linq;
using TimeAndBilling.Models.Repository.Interfaces;

namespace TimeAndBilling.Models.Repository
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private readonly AppDbContext _context;

        public TimeEntryRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TimeEntry> GetAllTimeEntries => 
            _context.TimeEntries
            .Where(p => p.Date >= DateTime.Today && p.Date <=DateTime.Today.AddDays(1));

        public TimeEntry AddNewTimeEntry(TimeEntry timeEntry)
        {
            TimeEntry newTimeEntry = new TimeEntry
            {
                Description = timeEntry.Description,
                Hours = timeEntry.Hours,
                ProjectID = timeEntry.ProjectID,
                EmployeeID = timeEntry.EmployeeID,
                Date = DateTime.Now
            };
            _context.Add(newTimeEntry);
            _context.SaveChanges();

            return newTimeEntry;
        }

        public void DeleteTimeEntry(int? timeEntryID)
        {
            var deleteTimeEntry = _context.TimeEntries.FirstOrDefault(te => te.TimeEntryID == timeEntryID);
            _context.Remove(deleteTimeEntry);
            _context.SaveChanges();
        }


        public TimeEntry UpdateTimeEntry(TimeEntry timeEntry)
        {
            var updateTimeEntry = _context.TimeEntries.FirstOrDefault(te => te.TimeEntryID == timeEntry.TimeEntryID);
            if (updateTimeEntry != null)
            {
                updateTimeEntry.Date = timeEntry.Date;
                updateTimeEntry.Description = timeEntry.Description;
                updateTimeEntry.Hours = timeEntry.Hours;
                updateTimeEntry.ProjectID = timeEntry.ProjectID;
            }

            _context.Update(updateTimeEntry);
            _context.SaveChanges();
            return updateTimeEntry;
        }
    }
}
