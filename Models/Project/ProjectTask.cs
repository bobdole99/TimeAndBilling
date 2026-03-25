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

        [Required]
        [Display(Name ="Task Owner")]
        public string TaskOwner { get; set; }

        [Display(Name = "Task Name")]
        [Required]
        public string TaskName { get; set; }
        
        [Display(Name = "Task Description")]
        public string TaskDescription { get; set; }

        [Display(Name ="Estimated Hours")]
        public double EstimatedHours { get; set; }

        [Display(Name ="Current Hours")]
        public double CurrentHours { get; set; }

        public bool Completed { get; set; }
    }
}
