using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeAndBilling.Models.Repository;

namespace TimeAndBilling.Models.MockRepository
{
    public class MockProjectRepository : IProjectRepository
    {
        public IEnumerable<Project> GetAllProjects => new List<Project>
        {
            new Project { ProjectName ="Time and Billing", ProjectCode = "TandB", ProjectDescription = "A time and billing application demonstrating MVVC", ProjectId= 1},
            new Project {ProjectName = "Backend Enhancements", ProjectCode = "BE01", ProjectDescription = "Numerous changes to the back end architecture", ProjectId = 2},
            new Project {ProjectName = "Frontend Enhancements", ProjectCode = "FE01", ProjectDescription = "Changes to the interface", ProjectId = 3}
        };
        public Project GetProjectByCode(string code)
        {
            return GetAllProjects.FirstOrDefault(e => e.ProjectCode == code);
        }

        public Project GetProjectByName(string name)
        {
            return GetAllProjects.FirstOrDefault(e => e.ProjectName == name);
        }
    }
}
