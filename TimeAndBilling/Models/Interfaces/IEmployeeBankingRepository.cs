namespace TimeAndBilling.Models.Interfaces
{
    public interface IEmployeeBankingRepository
    {
        EmployeeBanking GetEmployeeBankingInformationById(int id);
        EmployeeBanking AddEmployeeBankingInformation(EmployeeBanking employeeBanking);
        EmployeeBanking UpdateEmployeeBankingInformation(EmployeeBanking employeeBanking);
    }
}
