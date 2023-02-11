using Core.Models;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        Task Create(string username, string password, string email);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserById(int id);
        Task<User> GetAllUsers();
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
