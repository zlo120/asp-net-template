using Core.Models;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> Create(Product product);
        Task<Product> GetProductById(int id);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
