using BroasterWebApp.Entities;

namespace BroasterWebApp.interfaces
{

        public interface IProductService
        {
                Task AddProductAsync(Product prmProduct);
                Task<Product> GetProductByIdAsync(int prmId);
                Task<Product> GetProductByNameAsync(string prmUsername);
                Task<IEnumerable<Product>> GetAllAsync();
        }
}