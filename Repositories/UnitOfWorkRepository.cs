using BroasterWebApp.DataBase;
using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BroasterWebApp.repositories
{
        public class UnitOfWorkRepository : IUnitOfWork
        {
            private readonly DBContext _dbContext;
            private IDbContextTransaction _transaction;

            public UnitOfWorkRepository(DBContext dbcontext)
            {
                _dbContext = dbcontext;
            }

            public async Task BeginTransactionAsync()
            {
                _transaction = await _dbContext.Database.BeginTransactionAsync();
            }
            public async Task CommitAsync()
            {
                if (_transaction != null)
                    await _transaction.CommitAsync();
            }
            public async Task RollbackAsync()
            {
                if (_transaction != null)
                    await _transaction.RollbackAsync();
            }
            public async Task SaveChangesAsync()
            {
                await _dbContext.SaveChangesAsync();
            }
        }
}