using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models
{
    public class TimeEntry
    {
        Employee Employee { get; set; }
        Project Project { get; set; }
        string Description { get; set; }
        decimal Hours { get; set; }
    }
}
