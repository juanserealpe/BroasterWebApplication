using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using System.Globalization;
using System.Text.RegularExpressions;
using BroasterWebApp.repositories;

namespace BroasterWebApp.services
{

    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repositoryEmployee;
        private readonly IRepository<Account> _repositoryAccount;
        
        public EmployeeService(IRepository<Employee> prmRepositoryEmployee, IRepository<Account> repositoryAccount)
        {
            _repositoryEmployee = prmRepositoryEmployee;
            _repositoryAccount = repositoryAccount;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            if (!IsValidName(employee.FirstName))
                throw new ArgumentException("The first name isn't valid, please check.");
            if (!IsValidName(employee.LastName))
                throw new ArgumentException("The last name isn't valid, please check.");

            employee.FirstName = SanitizeName(employee.FirstName);
            employee.LastName = SanitizeName(employee.LastName);

            if (employee.FirstName.Length > 30)
                throw new ArgumentException("El nombre no puede tener más de 30 caracteres.");
            if (employee.LastName.Length > 30)
                throw new ArgumentException("El apellido no puede tener más de 30 caracteres.");

            await _repositoryEmployee.AddAsync(employee);
        }

        private string SanitizeName(string name)
        {
            name = name.Trim().ToLowerInvariant();
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name);
        }

        private bool IsValidName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑüÜ\s]+$");
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
            throw new Exception();
        }

        public async Task<int> GetUserRoleByUsernameAsync(string prmUsername)
        {
            var EmployeeResult = await _repositoryEmployee.GetByStringAsync(prmUsername);
            return EmployeeResult.IdRole;
        }
    }
}