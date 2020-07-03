using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models
{
    //Add a new project
    public class Project
    {
        public int ProjectID { get; set; }

        //Project name
        [Required(ErrorMessage = "Please enter a project name")]
        [Display(Name ="Project Name")]
        public string ProjectName { get; set; }
    
        //Project Code
        [Display(Name ="Project Code")]
        [StringLength(10)]
        public string ProjectCode { get; set; }

        //Project Description
        [Display(Name = "Project Description")]
        [StringLength(500)]
        public string ProjectDescription { get; set; }
    }
}
