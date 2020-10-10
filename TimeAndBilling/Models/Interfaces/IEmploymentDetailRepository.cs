using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeAndBilling.Models.Interfaces
{
    public interface IEmploymentDetailRepository
    {
        EmploymentDetail GetEmploymentDetailById(int id);
        EmploymentDetail AddEmploymentDetail(EmploymentDetail employmentDetail);
        EmploymentDetail UpdateEmploymentDetail(EmploymentDetail employmentDetail);
    }
}
