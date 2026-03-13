using CarbonFootprintTracker.Api.Models;
using CarbonFootprintTracker.Api.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CarbonFootprintTracker.Api.Repositories
{
    public interface IActivityRepository
    {
        Task<IEnumerable<Activity>> GetAllAsync(string userId);
        Task<Activity?> GetByIdAsync(string id);
        Task CreateAsync(Activity activity);
        Task UpdateAsync(string id, Activity activity);
        Task DeleteAsync(string id);
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
