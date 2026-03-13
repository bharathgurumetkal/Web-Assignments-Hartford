using CarbonFootprintTracker.Api.Configurations;
using CarbonFootprintTracker.Api.Interfaces;
using CarbonFootprintTracker.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarbonFootprintTracker.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _users = database.GetCollection<User>("Users");
        }

        public async Task<User?> GetByIdAsync(string id) =>
            await _users.Find(u => u.Id == id).FirstOrDefaultAsync();

        public async Task<User?> GetByEmailAsync(string email) =>
            await _users.Find(u => u.Email == email).FirstOrDefaultAsync();

        public async Task CreateAsync(User user) =>
            await _users.InsertOneAsync(user);

        public async Task UpdateAsync(string id, User user) =>
            await _users.ReplaceOneAsync(u => u.Id == id, user);

        public async Task DeleteAsync(string id) =>
            await _users.DeleteOneAsync(u => u.Id == id);
    }

    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoCollection<Activity> _activities;

        public ActivityRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _activities = database.GetCollection<Activity>("Activities");
        }

        public async Task<IEnumerable<Activity>> GetAllAsync(string userId) =>
            await _activities.Find(a => a.UserId == userId).ToListAsync();

        public async Task<Activity?> GetByIdAsync(string id) =>
            await _activities.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Activity activity) =>
            await _activities.InsertOneAsync(activity);

        public async Task UpdateAsync(string id, Activity activity) =>
            await _activities.ReplaceOneAsync(a => a.Id == id, activity);

        public async Task DeleteAsync(string id) =>
            await _activities.DeleteOneAsync(a => a.Id == id);
    }
}
