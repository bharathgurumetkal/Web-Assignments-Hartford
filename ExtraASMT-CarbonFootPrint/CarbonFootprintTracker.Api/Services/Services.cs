using CarbonFootprintTracker.Api.Helpers;
using CarbonFootprintTracker.Api.Interfaces;
using CarbonFootprintTracker.Api.Models;

namespace CarbonFootprintTracker.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public AuthService(IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<string> RegisterAsync(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            await _userRepository.CreateAsync(user);
            return _jwtHelper.GenerateToken(user);
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return _jwtHelper.GenerateToken(user);
        }
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByIdAsync(string id) => await _userRepository.GetByIdAsync(id);

        public async Task UpdateUserAsync(string id, User user) => await _userRepository.UpdateAsync(id, user);

        public async Task DeleteUserAsync(string id) => await _userRepository.DeleteAsync(id);
    }

    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<Activity>> GetUserActivitiesAsync(string userId) =>
            await _activityRepository.GetAllAsync(userId);

        public async Task<Activity?> GetActivityByIdAsync(string id) =>
            await _activityRepository.GetByIdAsync(id);

        public async Task<Activity> CreateActivityAsync(Activity activity)
        {
            activity.CarbonFootprint = CalculateCarbonFootprint(activity.ActivityType, activity.Value);
            await _activityRepository.CreateAsync(activity);
            return activity;
        }

        public async Task UpdateActivityAsync(string id, Activity activity)
        {
            activity.CarbonFootprint = CalculateCarbonFootprint(activity.ActivityType, activity.Value);
            await _activityRepository.UpdateAsync(id, activity);
        }

        public async Task DeleteActivityAsync(string id) =>
            await _activityRepository.DeleteAsync(id);

        public double CalculateCarbonFootprint(ActivityType type, double value)
        {
            return type switch
            {
                ActivityType.Energy => value * 0.5,     // 0.5 kg CO2 per kWh
                ActivityType.Transport => value * 0.2,  // 0.2 kg CO2 per km
                ActivityType.Waste => value * 1.5,      // 1.5 kg CO2 per kg
                _ => 0
            };
        }
    }
}
