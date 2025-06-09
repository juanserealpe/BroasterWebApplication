using BroasterWebApp.DataBase;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BroasterWebApp.repositories
{

    public class AccountRepository : IRepository<Account>
    {
        private readonly DBContext _dbContext;

        public AccountRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Account prmItem)
        {
            await _dbContext.AddAsync(prmItem);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int prmId)
        {
            var account = await _dbContext.Set<Account>().FindAsync(prmId);
            if (account != null)
            {
                _dbContext.Set<Account>().Remove(account);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Account prmItem)
        {
            _dbContext.Entry(prmItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _dbContext.Set<Account>().ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int prmId)
        {
            throw new NotImplementedException();
        }

        public async Task<Account> GetByStringAsync(string prmString)
        {
            return await _dbContext.Set<Account>()
                .FirstOrDefaultAsync(a => a.Username == prmString);
        }
    }
}