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

        //Is Employee active
        public bool IsActive { get; set; }

        //Email
        [Display(Name ="Personal Email")]
        public string PersonalEmail { get; set; }

        //Title
        public string Title { get; set; }
    }
}
