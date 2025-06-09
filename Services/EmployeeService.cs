using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using BroasterWebApp.repositories;

namespace BroasterWebApp.services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repositoryEmployee;
        private readonly IRepository<Account> _repositoryAccount;


        public EmployeeService(IRepository<Employee> prmRepositoryEmployee, IRepository<Account> repositoryAccount){
            _repositoryEmployee = prmRepositoryEmployee;
            _repositoryAccount = repositoryAccount;
        }

        public async Task AddEmployeeAsync(Employee prmEmployee)
        {
            await _repositoryEmployee.AddAsync(prmEmployee);
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _repositoryEmployee.GetAllAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int prmId)
        {
            return await _repositoryEmployee.GetByIdAsync(prmId);
        }

        public async Task<Employee> GetEmployeeByUsernameAsync(string prmUsername)
        {
            var employeeResult = await _repositoryAccount.GetByStringAsync(prmUsername);
            return await _repositoryEmployee.GetByIdAsync(employeeResult.IdEmployee);
        }

        public async Task<int> GetUserRoleByUsernameAsync(string prmUsername)
        {
            var EmployeeResult = await _repositoryEmployee.GetByStringAsync(prmUsername);
            return EmployeeResult.IdRole;
        }
    }
}