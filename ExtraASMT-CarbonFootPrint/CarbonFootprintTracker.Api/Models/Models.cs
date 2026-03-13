using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CarbonFootprintTracker.Api.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum ActivityType
    {
        Energy,
        Transport,
        Waste
    }

    public class Activity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = string.Empty;

        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; } // electricity units, kilometers, waste weight
        public double CarbonFootprint { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}
