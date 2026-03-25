using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models.Interfaces;

namespace TimeAndBilling.Models.Repository
{
    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly AppDbContext _context;


        public ProjectTaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProjectTask> GetAllProjectTasks 
            => _context.ProjectTasks;
       
        public ProjectTask GetProjectTaskById(int? projectTaskId)
        {
            return _context.ProjectTasks.FirstOrDefault(pt => pt.ProjectTaskID == projectTaskId);
        }

        public ProjectTask AddNewProjectTask(ProjectTask projectTask)
        {
            ProjectTask newProjectTask = new ProjectTask
            {
                Project = projectTask.Project,
                Completed = projectTask.Completed,
                CurrentHours = projectTask.CurrentHours,
                EstimatedHours = projectTask.EstimatedHours,
                TaskDescription = projectTask.TaskDescription,
                TaskName = projectTask.TaskName,
                TaskOwner = projectTask.TaskOwner
            };
            _context.Add(newProjectTask);
            _context.SaveChanges();
            return newProjectTask;
            
        }

        public ProjectTask DeleteProjectTask(int? projectTaskId)
        {
            var projectTask = GetProjectTaskById(projectTaskId);
            _context.Remove(projectTask);
            _context.SaveChanges();

            return projectTask;
        }

        public ProjectTask UpdateProjectTask(ProjectTask projectTask)
        {
            var updateProjectTask = _context.ProjectTasks.FirstOrDefault(pt => pt.ProjectTaskID == projectTask.ProjectTaskID);
            if (updateProjectTask != null)
            {
                updateProjectTask.Project = projectTask.Project;
                updateProjectTask.Completed = projectTask.Completed;
                updateProjectTask.CurrentHours = projectTask.CurrentHours;
                updateProjectTask.EstimatedHours = projectTask.EstimatedHours;
                updateProjectTask.TaskDescription = projectTask.TaskDescription;
                updateProjectTask.TaskName = projectTask.TaskName;
                updateProjectTask.TaskOwner = projectTask.TaskOwner;
            }

            _context.Update(updateProjectTask);
            _context.SaveChanges();
            return updateProjectTask;
            throw new NotImplementedException();
        }


        public IEnumerable<ProjectTask> GetProjectTaskByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
