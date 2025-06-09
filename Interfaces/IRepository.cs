namespace BroasterWebApp.interfaces
{

    public interface IRepository<T>
    {
        public Task<T> GetByIdAsync(int prmId);
        public Task<T> GetByStringAsync(string prmString);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task AddAsync(T prmItem);
        public Task EditAsync(T prmItem);
        public Task DeleteAsync(int prmId);
    }
}
