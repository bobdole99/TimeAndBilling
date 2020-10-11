namespace TimeAndBilling.Models.Interfaces
{
    public interface IEmployeeDetailRepository
    {
        EmployeeDetail GetEmployeeDetailById(int id);
        EmployeeDetail AddEmployeeDetail(EmployeeDetail employeeDetail);
        EmployeeDetail UpdateEmployeeDetail(EmployeeDetail employeeDetail);
    }
}
