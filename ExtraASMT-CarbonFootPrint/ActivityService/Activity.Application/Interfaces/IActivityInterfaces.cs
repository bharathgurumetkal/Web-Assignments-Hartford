using Activity.Domain.Entities;

namespace Activity.Application.Interfaces
{
    public interface IActivityRepository
    {
        Task<IEnumerable<ActivityEntry>> GetAllAsync(string userId);
        Task<ActivityEntry?> GetByIdAsync(string id);
        Task CreateAsync(ActivityEntry activity);
        Task UpdateAsync(string id, ActivityEntry activity);
        Task DeleteAsync(string id);
    }

    public interface IActivityService
    {
        Task<IEnumerable<ActivityEntry>> GetUserActivitiesAsync(string userId);
        Task<ActivityEntry?> GetActivityByIdAsync(string id);
        Task<ActivityEntry> CreateActivityAsync(ActivityEntry activity);
        Task UpdateActivityAsync(string id, ActivityEntry activity);
        Task DeleteActivityAsync(string id);
        double CalculateCarbonEmission(ActivityType type, double value);
    }
}
