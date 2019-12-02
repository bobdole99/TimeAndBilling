using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Project> GetAllProjects => _context.Projects;

        public Project GetProjectByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Project GetProjectByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
