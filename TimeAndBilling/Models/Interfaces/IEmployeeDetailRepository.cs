using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Interfaces
{
    public interface IEmployeeDetailRepository
    {
        EmployeeDetail GetEmployeeDetailById(int id);
    }
}
