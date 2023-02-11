using Core.Interfaces;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly Context _context;
        private readonly ILogger<StoreRepository> _logger;
        public StoreRepository(ILogger<StoreRepository> logger, Context context)
        {
            _context= context;
            _logger= logger;
        }
        public async Task<bool> Create(Store store)
        {
            _context.Stores.Add(store);
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

        public async Task<Store> GetStoreById(int id)
        {
            return await _context.Stores.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateStore(Store store)
        {
            var originalStore = await _context.Stores.Where(s => s.Id == store.Id).FirstOrDefaultAsync();
            if (originalStore is null)
            {
                return false;
            }

            originalStore.Name = store.Name;
            originalStore.Products = store.Products;
            originalStore.Users = store.Users;

            _context.Stores.Update(originalStore);

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

        public async Task<bool> DeleteStore(int id)
        {
            var store = await _context.Stores.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (store is null)
            {
                return false;
            }

            _context.Stores.Remove(store);

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
