using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models
{
    public class Employee
    {
        public int Id { get; set; }

        //First Name
        [Required(ErrorMessage = "Please enter a first name")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        //Middle Name
        [StringLength(50)]
        public string MiddleName { get; set; }  

        //Last Name
        [Required(ErrorMessage ="Please enter a last name")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        // DOB
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        [Required(ErrorMessage ="Please enter a date of birth")]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        //Address
        [Required(ErrorMessage = "Please enter a valid address")]
        [StringLength(100)]
        public string Address { get; set; }

        //Postal Code
        [Required(ErrorMessage = "Please enter a valid postal code")]
        public string PostalCode { get; set; }

        //Home Phone Number
        [Required(ErrorMessage ="Please enter a valid phone number")]
        [Display(Name = "Home Phone Number")]
        public string PhoneNumber { get; set; }

        //Alternate Phone Number
        public string AlternatePhoneNumber { get; set; }

        //Job Title
        [Required(ErrorMessage ="Please select a job title")]
        [Display(Name = "Job Title")]
        public string JobTitle { get; set; }

        //Is Employee active
        public bool IsActive { get; set; }
    }
}
