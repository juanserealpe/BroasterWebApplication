using BroasterWebApp.Entities;

namespace BroasterWebApp.interfaces
{

    public interface IUserDomainService
    {
        Task AddEmployee(Employee prmEmployee, Account prmAccount);

        Task<Employee> IsLoginValid(string prmUsername, string prmPassword);
    }
}