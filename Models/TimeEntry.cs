using System;
using System.ComponentModel.DataAnnotations;

namespace TimeAndBilling.Models
{
    public class TimeEntry
    {
        public int TimeEntryID { get; set; }
        public int EmployeeID { get; set; }

        public Project Project { get; set; }
        public int ProjectID { get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter the number of hours worked on this project")]
        public decimal Hours { get; set; }

        public DateTime Date { get; set; }

    }
}
