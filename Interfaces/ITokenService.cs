

using BroasterWebApp.Entities;

namespace BroasterWebApp.interfaces
{
    public interface ITokenService
    {
        string GenerateToken(Employee prmEmployee);
    }
}
