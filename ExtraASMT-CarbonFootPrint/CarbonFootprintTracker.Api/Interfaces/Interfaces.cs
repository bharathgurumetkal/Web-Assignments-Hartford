using CarbonFootprintTracker.Api.Models;

namespace CarbonFootprintTracker.Api.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string id);
        Task<User?> GetByEmailAsync(string email);
        Task CreateAsync(User user);
        Task UpdateAsync(string id, User user);
        Task DeleteAsync(string id);
    }

    public interface IAuthService
    {
        Task<string> RegisterAsync(User user, string password);
        Task<string?> LoginAsync(string email, string password);
    }

    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(string id);
        Task UpdateUserAsync(string id, User user);
        Task DeleteUserAsync(string id);
    }
}
