using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;


namespace TimeAndBilling.Models
{
    public class SeedEmployeeData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Employees.Any())
                {
                    return;
                }

                context.Employees.AddRange(
                    new Employee { 
                        FirstName = "John", 
                        LastName = "McTavish", 
                        IsActive = true, 
                        PersonalEmail = "john.mctavish@gmail.com", 
                        Title = "Software Developer" },
                    new Employee {
                        FirstName = "Sarah", 
                        LastName = "Sihnos", 
                        IsActive = true, 
                        PersonalEmail = "sarah.Sihnos@gmail.com", 
                        Title = "Software Developer" },
                    new Employee {
                        FirstName = "Jeff",
                        LastName = "Brimwall", 
                        IsActive = true, 
                        PersonalEmail = "jeff.brimwall@gmail.com", 
                        Title = "Software Developer" },
                    new Employee {
                        FirstName = "Crag", 
                        LastName = "Boulderson", 
                        IsActive = true, 
                        PersonalEmail = "craig.bouldersone@gmail.com", 
                        Title = "QA Analyst" }
                    );

                context.SaveChanges();
            }
        }
    }
}
