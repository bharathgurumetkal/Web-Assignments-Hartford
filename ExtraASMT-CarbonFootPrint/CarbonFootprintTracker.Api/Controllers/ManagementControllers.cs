using AutoMapper;
using CarbonFootprintTracker.Api.DTOs;
using CarbonFootprintTracker.Api.Interfaces;
using CarbonFootprintTracker.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarbonFootprintTracker.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UserDto userDto)
        {
            var existingUser = await _userService.GetUserByIdAsync(id);
            if (existingUser == null) return NotFound();

            existingUser.Name = userDto.Name;
            existingUser.Email = userDto.Email;

            await _userService.UpdateUserAsync(id, existingUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly IActivityService _activityService;
        private readonly IMapper _mapper;

        public ActivitiesController(IActivityService activityService, IMapper mapper)
        {
            _activityService = activityService;
            _mapper = mapper;
        }

        private string GetUserId() => User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityDto>>> GetActivities()
        {
            var activities = await _activityService.GetUserActivitiesAsync(GetUserId());
            return Ok(_mapper.Map<IEnumerable<ActivityDto>>(activities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityDto>> GetActivity(string id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null || activity.UserId != GetUserId()) return NotFound();
            return Ok(_mapper.Map<ActivityDto>(activity));
        }

        [HttpPost]
        public async Task<ActionResult<ActivityDto>> CreateActivity(ActivityCreateDto createDto)
        {
            var activity = _mapper.Map<Activity>(createDto);
            activity.UserId = GetUserId();
            
            var createdActivity = await _activityService.CreateActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivity), new { id = createdActivity.Id }, _mapper.Map<ActivityDto>(createdActivity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(string id, ActivityUpdateDto updateDto)
        {
            var existingActivity = await _activityService.GetActivityByIdAsync(id);
            if (existingActivity == null || existingActivity.UserId != GetUserId()) return NotFound();

            _mapper.Map(updateDto, existingActivity);
            await _activityService.UpdateActivityAsync(id, existingActivity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(string id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null || activity.UserId != GetUserId()) return NotFound();

            await _activityService.DeleteActivityAsync(id);
            return NoContent();
        }

        [HttpGet("{id}/carbon-footprint")]
        public async Task<ActionResult<object>> GetCarbonFootprint(string id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null || activity.UserId != GetUserId()) return NotFound();

            return Ok(new
            {
                ActivityId = activity.Id,
                ActivityType = activity.ActivityType.ToString(),
                Value = activity.Value,
                CarbonFootprint = activity.CarbonFootprint,
                Unit = "kg CO2"
            });
        }
    }
}
