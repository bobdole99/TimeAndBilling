using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models
{
    public class Absence
    {
        public int AbsenceID { get; set; }

        //Start Date
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Required(ErrorMessage = "Please enter the absence start date")]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }

        //End Date
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Required(ErrorMessage ="Please enter the absence end date")]
        [Display(Name ="End Date")]
        public DateTime EndDate { get; set; }


        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        
        //Reason
        [Required(ErrorMessage ="Please enter the reason for absence")]
        public string Reason { get; set; }
    }
}
