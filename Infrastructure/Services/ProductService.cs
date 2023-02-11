using Core.Interfaces;
using Core.Models;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;   
        }

        public async Task<bool> Create(string name, string description, float price, Store store, User creator)
        {
            var product = new Product()
            {
                Name = name,
                Description = description,
                Price = price,
                Store = store,
                User = creator
            };

            return await _productRepository.Create(product);
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productRepository.DeleteProduct(id);
        }
    }
}
