using BroasterWebApp.Entities;

namespace BroasterWebApp.interfaces
{

    public interface IAuthService
    {
        Task AddAccountAsync(Account prmAccount);
        Task<Employee> IsLoginValidAsync(string prmUsername, string prmPassword);
    }
}
