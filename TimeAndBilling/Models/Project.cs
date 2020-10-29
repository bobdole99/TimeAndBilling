using System.ComponentModel.DataAnnotations;

namespace TimeAndBilling.Models
{
    //Add a new project
    public class Project
    {
        public int? ProjectID { get; set; }

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

        //Project Manager
        [Display(Name ="Project Manager")]
        public string ProjectManager { get; set; }

        //Project Contact Email
        [Display(Name ="Project Contact Email")]
        public string ProjectContactEmail { get; set; }

        //Project Contact Phone
        [Display(Name ="Project Contact Phone")]
        public string ProjectContactPhone { get; set; } 

        //Estimated Project Hours
        [Display(Name ="Estimated Project Hours")]
        public double EstimatedProjectHours { get; set; }

        //Actual Project Hours
        [Display(Name ="Actual Project Hours")]
        public double ActualProjectHours { get; set; }

        //Billable Hours
        [Display(Name ="Billable Hours")]
        public double BillableHours { get; set; }

        //Completed
        public bool Completed { get; set; }
    }
}
