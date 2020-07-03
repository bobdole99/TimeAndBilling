using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models;

namespace TimeAndBilling.ViewModels
{
    public class TimeEntryViewModel
    {
        public IEnumerable<TimeEntry> TimeEntries { get; set; }

        //public TimeEntry TimeEntry { get; set; }
    }
}
