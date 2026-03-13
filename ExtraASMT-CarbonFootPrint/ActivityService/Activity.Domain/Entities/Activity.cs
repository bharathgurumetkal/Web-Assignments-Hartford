using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Activity.Domain.Entities
{
    public enum ActivityType
    {
        Energy,
        Transport,
        Waste
    }

    public class ActivityEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;

        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; } = string.Empty;

        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public double CarbonEmission { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
