using BroasterWebApp.Entities;

namespace BroasterWebApp.DTOs
{

    public class UserDomainDTO
    {
        public Employee employee { get; set; }
        public Account account { get; set; }

        public UserDomainDTO()
        {
            employee = new Employee(); 
            account = new Account();   
        }
    }

}