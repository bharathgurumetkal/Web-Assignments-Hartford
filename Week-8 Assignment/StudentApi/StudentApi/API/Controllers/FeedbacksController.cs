using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Application.DTOs.Feedbacks;
using StudentApi.Domain.Entities;
using StudentApi.Infrastructure.Data;
using System.Security.Claims;

namespace StudentApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FeedbacksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FeedbacksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Feedbacks
        [HttpGet]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<ActionResult<IEnumerable<FeedbackDto>>> GetFeedbacks()
        {
            var userRole = User.FindFirstValue(ClaimTypes.Role);
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IQueryable<Feedback> query = _context.Feedbacks
                .Include(f => f.Student)
                .Include(f => f.Trainer);

            if (userRole == "Trainer")
            {
                query = query.Where(f => f.TrainerId.ToString() == userIdStr);
            }

            var feedbacks = await query.Select(f => new FeedbackDto
            {
                Id = f.Id,
                StudentId = f.StudentId,
                StudentName = f.Student != null ? f.Student.Username : "Unknown",
                TrainerId = f.TrainerId,
                TrainerName = f.Trainer != null ? f.Trainer.Username : "Unknown",
                Message = f.Message,
                CreatedAt = f.CreatedAt
            }).ToListAsync();

            return Ok(feedbacks);
        }

        // POST: api/Feedbacks
        [HttpPost]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> CreateFeedback(CreateFeedbackDto dto)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

            var feedback = new Feedback
            {
                Id = Guid.NewGuid(),
                StudentId = Guid.Parse(userIdStr),
                TrainerId = dto.TrainerId,
                Message = dto.Message,
                CreatedAt = DateTime.UtcNow
            };

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Feedback submitted successfully" });
        }

        // GET: api/Feedbacks/trainers
        [HttpGet("trainers")]
        [Authorize(Roles = "Student")]
        public async Task<ActionResult> GetTrainers()
        {
            var trainers = await _context.Users
                .Where(u => u.Role == "Trainer")
                .Select(u => new { u.Id, u.Username })
                .ToListAsync();

            return Ok(trainers);
        }
    }
}
