using Activity.Application.Interfaces;
using Activity.Domain.Entities;

namespace Activity.Application.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<ActivityEntry>> GetUserActivitiesAsync(string userId) =>
            await _activityRepository.GetAllAsync(userId);

        public async Task<ActivityEntry?> GetActivityByIdAsync(string id) =>
            await _activityRepository.GetByIdAsync(id);

        public async Task<ActivityEntry> CreateActivityAsync(ActivityEntry activity)
        {
            activity.CarbonEmission = CalculateCarbonEmission(activity.ActivityType, activity.Value);
            await _activityRepository.CreateAsync(activity);
            return activity;
        }

        public async Task UpdateActivityAsync(string id, ActivityEntry activity)
        {
            activity.CarbonEmission = CalculateCarbonEmission(activity.ActivityType, activity.Value);
            await _activityRepository.UpdateAsync(id, activity);
        }

        public async Task DeleteActivityAsync(string id) =>
            await _activityRepository.DeleteAsync(id);

        public double CalculateCarbonEmission(ActivityType type, double value)
        {
            return type switch
            {
                ActivityType.Energy => value * 0.5,
                ActivityType.Transport => value * 0.21,
                ActivityType.Waste => value * 0.3,
                _ => 0
            };
        }
    }
}
