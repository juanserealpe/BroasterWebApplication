using BroasterWebApp.Entities;
using BroasterWebApp.interfaces;

namespace BroasterWebApp.services
{

    public class ProductService : IProductService
    {

        private readonly IRepository<Product> _repositoryProduct;

        public ProductService(IRepository<Product> repositoryProduct)
        {
            this._repositoryProduct = repositoryProduct;
        }

        public async Task AddProductAsync(Product prmProduct)
        {
            await _repositoryProduct.AddAsync(prmProduct);
        }

        public async Task<IEnumerable<Product>> GetAllAsync() =>
        await _repositoryProduct.GetAllAsync();

        public Task<Product> GetProductByIdAsync(int prmId) =>
        _repositoryProduct.GetByIdAsync(prmId);

        public Task<Product> GetProductByNameAsync(string prmName) =>
        _repositoryProduct.GetByStringAsync(prmName);
    }

}