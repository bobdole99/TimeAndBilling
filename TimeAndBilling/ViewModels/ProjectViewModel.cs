﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models;

namespace TimeAndBilling.ViewModels
{
    public class ProjectViewModel
    {
        public IEnumerable<Project> Projects { get; set; }
    }
}
