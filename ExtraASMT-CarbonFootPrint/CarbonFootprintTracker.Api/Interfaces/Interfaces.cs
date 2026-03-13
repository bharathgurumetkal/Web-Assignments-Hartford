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

    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAllAsync(string userId);
        Task<Activity?> GetByIdAsync(string id);
        Task CreateAsync(Activity activity);
        Task UpdateAsync(string id, Activity activity);
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

    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetUserActivitiesAsync(string userId);
        Task<Activity?> GetActivityByIdAsync(string id);
        Task<Activity> CreateActivityAsync(Activity activity);
        Task UpdateActivityAsync(string id, Activity activity);
        Task DeleteActivityAsync(string id);
        double CalculateCarbonFootprint(ActivityType type, double value);
    }
}
