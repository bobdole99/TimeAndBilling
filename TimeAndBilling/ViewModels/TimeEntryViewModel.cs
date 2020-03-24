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

        [Required]
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public IEnumerable<SelectListItem> Employees { get; set; }

        public Project Project { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }

        [Required(ErrorMessage = "Please provide a description")]

        public string Description { get; set; }

        [Required(ErrorMessage = "Enter the number of hours worked on this project")]
        public decimal Hours { get; set; }

        public IEnumerable<TimeEntry> TimeEntries { get; set; }
    }
}
