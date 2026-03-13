using Authentication.Domain.Entities;

namespace Authentication.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string id);
        Task<User?> GetByEmailAsync(string email);
        Task CreateAsync(User user);
    }

    public interface IAuthService
    {
        Task<string> RegisterAsync(User user, string password);
        Task<string?> LoginAsync(string email, string password);
    }
}
