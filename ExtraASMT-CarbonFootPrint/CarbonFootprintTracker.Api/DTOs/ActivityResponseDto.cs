using CarbonFootprintTracker.Api.Models;

namespace CarbonFootprintTracker.Api.DTOs
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
}
