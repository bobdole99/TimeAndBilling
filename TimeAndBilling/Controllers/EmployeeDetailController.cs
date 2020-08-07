using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Controllers
{
    public class EmployeeDetailController : Controller
    {
        public IActionResult Edit(int? id)
        {
            return View();
        }
    }
}
