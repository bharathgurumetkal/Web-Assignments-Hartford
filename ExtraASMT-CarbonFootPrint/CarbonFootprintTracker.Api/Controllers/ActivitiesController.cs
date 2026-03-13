using AutoMapper;
using CarbonFootprintTracker.Api.DTOs;
using CarbonFootprintTracker.Api.Services;
using CarbonFootprintTracker.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarbonFootprintTracker.Api.Controllers
{
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
        public async Task<ActionResult<IEnumerable<ActivityResponseDto>>> GetActivities()
        {
            var activities = await _activityService.GetUserActivitiesAsync(GetUserId());
            return Ok(_mapper.Map<IEnumerable<ActivityResponseDto>>(activities));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityResponseDto>> GetActivity(string id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null || activity.UserId != GetUserId()) return NotFound();
            return Ok(_mapper.Map<ActivityResponseDto>(activity));
        }

        [HttpPost]
        public async Task<ActionResult<ActivityResponseDto>> CreateActivity(CreateActivityDto createDto)
        {
            var activity = _mapper.Map<Activity>(createDto);
            activity.UserId = GetUserId();
            
            var createdActivity = await _activityService.CreateActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivity), new { id = createdActivity.Id }, _mapper.Map<ActivityResponseDto>(createdActivity));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(string id, UpdateActivityDto updateDto)
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
                CarbonEmission = activity.CarbonEmission,
                Unit = "kg CO2"
            });
        }
    }
}
