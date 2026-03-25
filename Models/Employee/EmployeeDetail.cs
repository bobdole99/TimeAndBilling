using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace TimeAndBilling.Models
{
    public class EmployeeDetail
    {
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public int EmployeeDetailID { get; set; }

        //Field to pass full name to employee details page
        [NotMapped]
        public string FullName { get; set; }

        // DOB
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Required(ErrorMessage = "Please enter a date of birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        //Gender
        [Required(ErrorMessage ="Please specify a gender")]
        public string Gender { get; set; }

        //Marital Status
        [Display(Name ="Marital Status")]
        public string MaritalStatus { get; set; }

        //Nationality
        public string Nationality { get; set; }

        //Home Phone Number
        [Required(ErrorMessage = "Please enter a valid phone number")]
        [Display(Name = "Home Phone Number")]
        public string PhoneNumber { get; set; }

        //Alternate Phone Number
        [Display(Name = "Alternate Phone Number")]
        public string AlternatePhoneNumber { get; set; }

        //Emergency Phone Number
        [Display(Name = "Emergency Phone Number")]
        public string EmergencyPhoneNumber { get; set; }

        //Address
        [Required(ErrorMessage = "Please enter a valid address")]
        [StringLength(100)]
        public string Address { get; set; }

        //Postal Code
        [Required(ErrorMessage = "Please enter a valid postal code")]
        public string PostalCode { get; set; }

        //City
        [Required(ErrorMessage = "Invalid city")]
        public string City { get; set; }

        //Province/State
        [Required(ErrorMessage = "Invaid State/Province")]
        [Display(Name ="Province/State")]
        public string ProvinceState { get; set; }

        //Country
        [Required(ErrorMessage = "Invalid Country")]
        public string Country { get; set; }
    }
}
