using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Employee = timeEntry.Employee,
                Project = timeEntry.Project,
                Hours = timeEntry.Hours,
                ProjectID = timeEntry.ProjectID,
                EmployeeID = timeEntry.EmployeeID,
                Date = DateTime.Now
            };
            _context.Add(newTimeEntry);
            _context.SaveChanges();

            return newTimeEntry;
        }

        public TimeEntry DeleteTimeEntry(TimeEntry timeEntry)
        {
            var deleteTimeEntry = _context.TimeEntries.FirstOrDefault(te => te.TimeEntryID == timeEntry.TimeEntryID);
            _context.Remove(deleteTimeEntry);
            _context.SaveChanges();

            return deleteTimeEntry;
        }
    }
}
