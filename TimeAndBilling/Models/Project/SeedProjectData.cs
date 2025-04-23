using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TimeAndBilling.Models
{
    public class SeedProjectData
    {
        public static void Intialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Projects.Any())
                {
                    return;
                }

                context.Projects.AddRange(
                    new Project { 
                        ProjectName = "Refactor front end UI",
                        ProjectCode = "UI1212", 
                        ProjectDescription = "Clean up some code that was introduced in the previous story" },
                    new Project {
                        ProjectName = "Refactor bad end code", 
                        ProjectCode = "BE6652", 
                        ProjectDescription = "Clean up back end code that was introduced in the prevous story" },
                    new Project { 
                        ProjectName = "Create new banking information profile", 
                        ProjectCode = "DEV66552", 
                        ProjectDescription = "Firt story in a much larger epic to add a cleaner baking information portal for users" }
                    );

                context.SaveChanges();
            }

                using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
                {
                    if (context.ProjectTasks.Any())
                    {
                        return;
                    }

                    context.ProjectTasks.AddRange(
                    new ProjectTask { 
                        ProjectID = 1, 
                        TaskName = "Address previous pull request comments", 
                        TaskOwner = "Sarah", 
                        TaskDescription = "Delete unused integration test and update previous ones to use new framework" },
                    new ProjectTask { 
                        ProjectID = 2, 
                        TaskName = "Address previous pull request comments", 
                        TaskOwner = "Sarah", TaskDescription = "Improve query performace from suggetions in pull request" },
                    new ProjectTask { 
                        ProjectID = 3, 
                        TaskName = "Add required create profile button", 
                        TaskOwner = "Jeff", 
                        TaskDescription = "Add a create profile button at the top of the page" },
                    new ProjectTask { 
                        ProjectID = 3, 
                        TaskName = "Figure out if we can reuse exiting banking information", 
                        TaskOwner = "Jeff", TaskDescription = "Just a spike to see if how much of the current banking information we can reuse" },
                    new ProjectTask { 
                        ProjectID = 3, 
                        TaskName = "Add redirect to new profile page", 
                        TaskOwner = "Jeff", TaskDescription = "Introduce redirect functionality to out newly created button" }
                    );
                context.SaveChanges();
            }
        }
    }
}
