using Activity.Domain.Entities;

namespace Activity.Application.DTOs
{
    public class ActivityResponseDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public double CarbonEmission { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateActivityDto
    {
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
    }

    public class UpdateActivityDto
    {
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
    }
}
