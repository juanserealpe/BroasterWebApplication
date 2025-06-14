﻿using BroasterWebApp.DataBase;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using Microsoft.EntityFrameworkCore;

namespace BroasterWebApp.repositories
{

    public class EmployeeRepository : IRepository<Employee>
    {

        private readonly DBContext _dbContext;

        public EmployeeRepository(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Employee prmItem)
        {
            await _dbContext.AddAsync(prmItem);
        }

        public async Task DeleteAsync(int prmId)
        {
            var employeeResult = await _dbContext.Set<Employee>().FindAsync(prmId);
            if (employeeResult != null)
            {
                _dbContext.Set<Employee>().Remove(employeeResult);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Employee prmItem)
        {
            _dbContext.Entry(prmItem).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _dbContext.Set<Employee>().ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _dbContext.Employees
                .Include(e => e.Role)
                    .ThenInclude(r => r.RoleType)
                .FirstOrDefaultAsync(e => e.IdEmployee == id);
        }


        public Task<Employee> GetByStringAsync(string prmString)
        {
            throw new NotImplementedException();
        }
    }
}