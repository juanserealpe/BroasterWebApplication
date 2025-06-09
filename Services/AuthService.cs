using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;

namespace BroasterWebApp.services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public AuthService(IRepository<Account> prmAccountRepository, IRepository<Employee> employeeRepository)
        {
            _accountRepository = prmAccountRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task AddAccountAsync(Account prmAccount)
        {
            prmAccount.PasswordHash = prmAccount.PasswordHash.Trim();
            prmAccount.PasswordHash = BCrypt.Net.BCrypt.HashPassword(prmAccount.PasswordHash);
            await _accountRepository.AddAsync(prmAccount);
        }

        public async Task<Employee> IsLoginValidAsync(string prmUsername, string prmPassword)
        {
            if (string.IsNullOrWhiteSpace(prmUsername))
                return null;

            var accountResult = await _accountRepository.GetByStringAsync(prmUsername.Trim());

            string storedHash = accountResult.PasswordHash.Trim();
            string passwordToVerify = prmPassword.Trim();
            if (!BCrypt.Net.BCrypt.Verify(prmPassword, storedHash))
            {
                //CONTRASEÑA FALLIDA ENTONCES AGREGA UN INTENTO FALLIDO A LA CUENTA. 
                //PD: A los 3 intentos se deberá de bloquear la cuenta.
                return null;
            }
            return await _employeeRepository.GetByIdAsync(accountResult.IdEmployee);
        }
        
        public async Task<Account> GetAccountAsyncByUsername(string prmUsername)
        {
            return await _accountRepository.GetByStringAsync(prmUsername);
        }
    }
}