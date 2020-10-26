using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace TimeAndBilling.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<EmployeeDetail> EmployeeDetails { get; set; }
        public DbSet<EmploymentDetail> EmploymentDetails { get; set; }
        public DbSet<EmployeeBanking> EmployeeBankings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                new Project()
                {
                    ProjectID = 1,
                    ProjectName = "Front End Enhancements",
                    ProjectCode = "12a",
                    ProjectDescription = "Update the outdated front end UI to give it a more modern look and feel"
                },
                new Project()
                {
                    ProjectID = 2,
                    ProjectName = "Back End Enhancements",
                    ProjectCode = "12b",
                    ProjectDescription = "Update the outdated back end archietecture to improve performance"
                },
                new Project()
                {
                    ProjectID = 3,
                    ProjectName = "User Interface Tests",
                    ProjectCode = "UIa",
                    ProjectDescription = "Project to create user interface tests"
                },
                new Project()
                {
                    ProjectID = 4,
                    ProjectName = "Integrations Tests",
                    ProjectCode = "INTa",
                    ProjectDescription = "Project to create integrations tests"
                },
                new Project()
                {
                    ProjectID = 5,
                    ProjectName = "Database upgrades",
                    ProjectCode = "DB-tb",
                    ProjectDescription = "Upgrade MS SQL version on server"
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
