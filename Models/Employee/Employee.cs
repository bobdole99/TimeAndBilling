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
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Please enter a first name")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }  

        [Required(ErrorMessage ="Please enter a last name")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        [Display(Name ="Personal Email")]
        public string PersonalEmail { get; set; }

        //Title
        public string Title { get; set; }
    }
}
