using Core.Models;

namespace Core.Interfaces
{
    public interface IProductService
    {
        Task<bool> Create(string name, string description, float price, Store store, User creator);
        Task<Product> GetProductById(int id);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
    }
}
