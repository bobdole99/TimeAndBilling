using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public IActionResult List()
        {

        }

        public IActionResult Add()
        {

        }

        public IActionResult Edit()
        {

        }
    }
}
