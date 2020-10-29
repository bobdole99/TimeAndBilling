using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models
{
    public class ProjectTask
    {
        public Project Project { get; set; }
        public int ProjectID { get; set; }
        public int ProjectTaskID { get; set; }

        //Task Owner
        [Required]
        [Display(Name ="Task Owner")]
        public string TaskOwner { get; set; }

        //Task Name
        [Display(Name = "Task Name")]
        [Required]
        public string TaskName { get; set; }
        
        //Task Description
        [Display(Name = "Task Description")]
        public string TaskDescription { get; set; }

        //Estimated Hours
        [Display(Name ="Estimated Hours")]
        public double EstimatedHours { get; set; }

        //Current Hours
        [Display(Name ="Current Hours")]
        public double CurrentHours { get; set; }

        //Is completed
        public bool Completed { get; set; }
    }
}
