using BroasterWebApp.Entities;

namespace BroasterWebApp.interfaces
{

    public interface IUnitOfWork
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChangesAsync();
    }
}
