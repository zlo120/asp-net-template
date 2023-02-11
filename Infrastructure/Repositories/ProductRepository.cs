using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ILogger<ProductRepository> logger, Context context)
        {
            _context= context;
            _logger= logger;
        }

        public async Task<bool> Create(Product product)
        {
            _context.Products.Add(product);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Critical error occured when saving changes: {ex}", DateTime.UtcNow.ToLongTimeString());
                return false;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var originalProduct = await _context.Products.Where(p => p.Id == product.Id).FirstOrDefaultAsync();
            if (originalProduct is null)
            {
                return false;
            }

            originalProduct.Id = product.Id;
            originalProduct.Name = product.Name;
            originalProduct.Description= product.Description;
            originalProduct.Price = product.Price;
            originalProduct.User = product.User;
            originalProduct.UserId = product.UserId;
            originalProduct.Store = product.Store;
            originalProduct.StoreId = product.StoreId;

            _context.Products.Update(originalProduct);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Critical error occured when saving changes: {ex}", DateTime.UtcNow.ToLongTimeString());
                return false;
            }
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (product is null)
            {
                return false;
            }

            _context.Products.Remove(product);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Critical error occured when saving changes: {ex}", DateTime.UtcNow.ToLongTimeString());
                return false;
            }
        }
    }
}
