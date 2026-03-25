using Microsoft.AspNetCore.Mvc;
using TimeAndBilling.Models;
using TimeAndBilling.Models.Interfaces;


namespace TimeAndBilling.Controllers
{
    public class ProjectTaskController : Controller
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        public ProjectTaskController(IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }


        public IActionResult Update(ProjectTask projectTask)
        {
            return null;
        }

        public IActionResult Edit(int? id)
        {

            return null;
        }


        public IActionResult List(string searchString)
        {

            return null;
        }


        public IActionResult Delete(int? id)
        {

            return null;
        }
    }
}
