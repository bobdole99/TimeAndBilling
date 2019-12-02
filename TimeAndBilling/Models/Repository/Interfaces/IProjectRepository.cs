using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Repository
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetAllProjects { get;  }

        Project GetProjectByName(string name);
        Project GetProjectByCode(string code);

    }
}
