﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models;

namespace TimeAndBilling.ViewModels
{
    public class ProjectTaskViewModel
    {
        public IEnumerable<ProjectTask> ProjectTasks { get; set; }
        public ProjectTask ProjectTask { get; set; }
    }
}
