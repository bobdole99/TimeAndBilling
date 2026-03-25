using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Interfaces
{
    public interface IProjectTaskRepository
    {
        IEnumerable<ProjectTask> GetAllProjectTasks { get; }

        IEnumerable<ProjectTask> GetProjectTaskByName(string name);

        ProjectTask GetProjectTaskById(int? projectTaskId);

        public ProjectTask AddNewProjectTask(ProjectTask projectTask);
        public ProjectTask DeleteProjectTask(int? projectTaskId);
        public ProjectTask UpdateProjectTask(ProjectTask projectTask);
    }
}
