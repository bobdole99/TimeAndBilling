using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace TimeAndBilling.Models
{
    public class EmploymentDetail
    {
        public int EmploymentDetailID { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        
        //Field to pass full name to employee details page
        [NotMapped]
        public string FullName { get; set; }

        //Job Title
        [Required(ErrorMessage = "Please select a job title")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        //Salary
        public double Salary { get; set; } 

        //Hourly Rate
        [Display(Name ="Hourly Rate")]
        public double HourlyRate { get; set; }

        //Contractor
        public bool Contractor { get; set; }
        
        //Start Date
        [Display(Name ="Start Date")]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }
        
        //Leave Date
        [Display(Name ="Leave Date")]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime LeaveDate { get; set; }

        //Department
        public string Department { get; set; }

        //Manager
        public string Manager { get; set; }

        //Social Insurance Number
        [Display(Name ="SSN")]
        public string SSN { get; set; }

        //Employee Number (auto generated)
        [Display(Name ="Employee Number")]
        [Required(ErrorMessage ="Please enter a unique employee number")]
        public string EmployeeNumber { get; set; }

        //Work Email (auto generated)
        [Display(Name ="Work Email")]
        [Required(ErrorMessage ="Please enter a unique email address")]
        public string WorkEmail { get; set; }
    }
}
