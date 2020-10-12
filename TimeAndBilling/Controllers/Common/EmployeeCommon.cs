using Microsoft.AspNetCore.Mvc;

namespace TimeAndBilling.Controllers.Common
{
    public class EmployeeCommon :Controller
    {
        public IActionResult Cancel()
        {
            return RedirectToAction("List", "Employee");
        }
    }
}
