using Core.Models;

namespace Core.Interfaces
{
    public interface IStoreService
    {
        Task Create(string name, ICollection<User>? users);
        Task Create(string name, User? user);
        Task<Store> GetStoreById(int id);
        Task<bool> UpdateStore(Store store);
        Task<bool> DeleteStore(int id);
    }
}
