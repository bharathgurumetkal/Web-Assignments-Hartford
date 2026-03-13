using CarbonFootprintTracker.Api.Models;

namespace CarbonFootprintTracker.Api.DTOs
{
    public class CreateActivityDto
    {
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
    }
}
