namespace TimeAndBilling.Models.Interfaces
{
    public interface IEmploymentDetailRepository
    {
        EmploymentDetail GetEmploymentDetailById(int id);
        EmploymentDetail AddEmploymentDetail(EmploymentDetail employmentDetail);
        EmploymentDetail UpdateEmploymentDetail(EmploymentDetail employmentDetail);
        void DeleteEmploymentDetail(int id);
    }
}
