using BroasterWebApp.DataBase;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BroasterWebApp.repositories
{

    public class ProductRepository : IRepository<Product>
    {

        private readonly DBContext _dbContext;

        public ProductRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Product> GetByIdAsync(int prmId){
            throw new Exception();
        }
        public Task<Product> GetByStringAsync(string prmString){
            throw new Exception();
        }
        public async Task<IEnumerable<Product>> GetAllAsync(){
            return await _dbContext.Set<Product>().ToListAsync();
        }
        public async Task AddAsync(Product prmItem){
            await _dbContext.AddAsync(prmItem);
            await _dbContext.SaveChangesAsync();
        }
        public async Task EditAsync(Product prmItem){
            _dbContext.Entry(prmItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public Task DeleteAsync(int prmId){
            throw new Exception();
        }

    }
}