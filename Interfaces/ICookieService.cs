using BroasterWebApp.Entities;

namespace BroasterWebApp.interfaces
{

    public interface ICookieService
    {
        Task SignInAsync(Employee employee, bool isPersistent = false);
        Task SignOutAsync();
    }
}