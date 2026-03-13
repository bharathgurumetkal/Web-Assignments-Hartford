using CarbonFootprintTracker.Api.Models;

namespace CarbonFootprintTracker.Api.DTOs
{
    public class UserDto
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class UserRegisterDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserLoginDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public UserDto User { get; set; } = new();
    }

    public class ActivityDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
        public double CarbonFootprint { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class ActivityCreateDto
    {
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
    }

    public class ActivityUpdateDto
    {
        public ActivityType ActivityType { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Value { get; set; }
    }
}
