using Core.Models;

namespace Core.Interfaces
{
    public interface IStoreRepository
    {
        Task<bool> Create(Store store);
        Task<Store> GetStoreById(int id);
        Task<bool> UpdateStore(Store store);
        Task<bool> DeleteStore(int id);
    }
}
