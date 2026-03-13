using Activity.Application.Interfaces;
using Activity.Domain.Entities;
using Activity.Infrastructure.Configurations;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Activity.Infrastructure.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoCollection<ActivityEntry> _activities;

        public ActivityRepository(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            var database = client.GetDatabase(settings.Value.DatabaseName);
            _activities = database.GetCollection<ActivityEntry>("Activities");
        }

        public async Task<IEnumerable<ActivityEntry>> GetAllAsync(string userId) =>
            await _activities.Find(a => a.UserId == userId).ToListAsync();

        public async Task<ActivityEntry?> GetByIdAsync(string id) =>
            await _activities.Find(a => a.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(ActivityEntry activity) =>
            await _activities.InsertOneAsync(activity);

        public async Task UpdateAsync(string id, ActivityEntry activity) =>
            await _activities.ReplaceOneAsync(a => a.Id == id, activity);

        public async Task DeleteAsync(string id) =>
            await _activities.DeleteOneAsync(a => a.Id == id);
    }
}
