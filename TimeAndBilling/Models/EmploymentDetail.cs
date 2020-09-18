using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models
{
    public class EmploymentDetail
    {
        public Employee EmployeeID { get; }

        public int EmploymentDetailID { get; set; }

        //Job Title
        [Required(ErrorMessage = "Please select a job title")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        //Salary
        double Salary { get; set; } 

        //Hourly Rate
        [Display(Name ="Hourly Rate")]
        double HourlyRate { get; set; }

        //Contractor
        bool Contractor { get; set; }

    }
}
