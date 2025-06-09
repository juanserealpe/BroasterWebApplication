using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;

namespace BroasterWebApp
{

    public class UserDomainService : IUserDomainService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IAuthService _authmeService;
        private readonly IUnitOfWork _unitOfWork;

        public UserDomainService(IEmployeeService employeeService, IAuthService authmeService
            , IUnitOfWork unitOfWork)
        {
            _employeeService = employeeService;
            _authmeService = authmeService;
            _unitOfWork = unitOfWork;
        }

        public async Task AddEmployee(Employee prmEmployee, Account prmAccount)
        {
            if (await _employeeService.GetEmployeeByIdAsync(prmEmployee.IdEmployee) != null)
                throw new Exception("Identification already exist");
            if (await _authmeService.GetAccountAsyncByUsername(prmAccount.Username) != null)
                throw new Exception("Username already exist");
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                await _employeeService.AddEmployeeAsync(prmEmployee);
                prmAccount.IdEmployee = prmEmployee.IdEmployee;
                await _authmeService.AddAccountAsync(prmAccount);
                await _unitOfWork.SaveChangesAsync();  // Guarda todos los cambios en la BD
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExistEmployee(string prmUsername, int prmIdEmployee)
        {
            if (await _employeeService.GetEmployeeByIdAsync(prmIdEmployee) != null)
                return true;
            if (await _authmeService.GetAccountAsyncByUsername(prmUsername) != null)
                return true;
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