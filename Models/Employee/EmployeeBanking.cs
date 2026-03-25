using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeAndBilling.Models
{
    public class EmployeeBanking
    {
        public Employee Employee { get; set; }
        public int EmployeeID { get; set; }
        public int EmployeeBankingID {get;set;}

        //Field to pass full name to employee details page
        [NotMapped]
        public string FullName { get; set; }

        //Name of Bank
        [Required(ErrorMessage ="Please enter the name of the bank")]
        [Display(Name ="Name of Bank")]
        public String NameOfBank { get; set; }
        
        //Institute NUmber
        [Required(ErrorMessage ="Please enter the bank's inistitute number")]
        [Display(Name ="Institute Number")]
        public int InstituteNumber { get; set; }

        //Transit Number
        [Required(ErrorMessage = "Please enter the bank's transit number")]
        [Display(Name ="Transit Number")]
        public int TransitNumber { get; set; } 

        //Account Number
        [Required(ErrorMessage ="Please enter the employee's account number")]
        [Display(Name ="Account Number")]
        public int AccountNumber { get; set; }

        //City
        [Required(ErrorMessage = "Enter the city")]
        public String City { get; set; }

        //Province
        [Required(ErrorMessage ="Enter the province")]
        public String Province { get; set; }
   
        //Postal Code
        [Required(ErrorMessage ="Please enter the postal code")]
        [Display(Name ="Postal Code")]
        public String PostalCode { get; set; }
    }
}
