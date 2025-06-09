using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;

namespace BroasterWebApp
{

    public class UserDomainService : IUserDomainService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAuthService _authmeService;

        public UserDomainService(IEmployeeService employeeService, IAuthService authmeService){
            _employeeService = employeeService;
            _authmeService = authmeService;
        }

        public async Task AddEmployee(Employee prmEmployee, Account prmAccount)
        {
            if (await ExistEmployee(prmAccount.Username))
                throw new Exception("Identification already exist");
        }

        public async Task<bool> ExistEmployee(string prmUsername)
        {
            if (await _employeeService.GetEmployeeByUsernameAsync(prmUsername) != null) return true; //mal
            return false;
        }

        public async Task<Employee> IsLoginValid(string prmUsername, string prmPassword)
        {
            var employeeResultLogin = await _authmeService.IsLoginValidAsync(prmUsername, prmPassword);
            if (employeeResultLogin != null) return employeeResultLogin;
            return null;
        }
    }
}