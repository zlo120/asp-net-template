using Core.Interfaces;
using Core.Models;

namespace Infrastructure.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;
        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository; 
        }

        public async Task<bool> Create(string name, ICollection<User>? users)
        {
            var store = new Store() { 
                Name = name, 
                Users = users 
            };

            return await _storeRepository.Create(store);
        }

        public async Task<bool> Create(string name, User? user)
        {
            var store = new Store()
            {
                Name = name,
                Users = new List<User>() { user }
            };

            return await _storeRepository.Create(store);
        }

        public async Task<Store> GetStoreById(int id)
        {
            return await _storeRepository.GetStoreById(id);
        }

        public async Task<bool> UpdateStore(Store store)
        {
            return await _storeRepository.UpdateStore(store);
        }

        public async Task<bool> DeleteStore(int id)
        {
            return await _storeRepository.DeleteStore(id);
        }
    }
}
