using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Application.DTOs.StudyMaterials;
using StudentApi.Domain.Entities;
using StudentApi.Infrastructure.Data;
using System.Security.Claims;

namespace StudentApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudyMaterialsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudyMaterialsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StudyMaterials
        [HttpGet]
        [Authorize(Roles = "Admin,Trainer,Student")]
        public async Task<ActionResult<IEnumerable<StudyMaterialDto>>> GetStudyMaterials()
        {
            var materials = await _context.StudyMaterials
                .Include(s => s.Trainer)
                .Select(s => new StudyMaterialDto
                {
                    Id = s.Id,
                    Title = s.Title,
                    Description = s.Description,
                    FileUrl = s.FileUrl,
                    TrainerId = s.TrainerId,
                    TrainerName = s.Trainer != null ? s.Trainer.Username : "Unknown",
                    CreatedAt = s.CreatedAt
                }).ToListAsync();

            return Ok(materials);
        }

        // GET: api/StudyMaterials/{id}
        [HttpGet("{id:guid}")]
        [Authorize(Roles = "Admin,Trainer,Student")]
        public async Task<ActionResult<StudyMaterialDto>> GetStudyMaterial(Guid id)
        {
            var material = await _context.StudyMaterials
                .Include(s => s.Trainer)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (material == null)
                return NotFound(new { message = "Study material not found" });

            return Ok(new StudyMaterialDto
            {
                Id = material.Id,
                Title = material.Title,
                Description = material.Description,
                FileUrl = material.FileUrl,
                TrainerId = material.TrainerId,
                TrainerName = material.Trainer?.Username,
                CreatedAt = material.CreatedAt
            });
        }

        // POST: api/StudyMaterials
        [HttpPost]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<ActionResult<StudyMaterialDto>> CreateStudyMaterial(CreateStudyMaterialDto dto)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userIdStr)) return Unauthorized();

            var material = new StudyMaterial
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Description = dto.Description,
                FileUrl = dto.FileUrl,
                TrainerId = Guid.Parse(userIdStr),
                CreatedAt = DateTime.UtcNow
            };

            _context.StudyMaterials.Add(material);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudyMaterial), new { id = material.Id }, new StudyMaterialDto
            {
                Id = material.Id,
                Title = material.Title,
                Description = material.Description,
                FileUrl = material.FileUrl,
                TrainerId = material.TrainerId,
                CreatedAt = material.CreatedAt
            });
        }

        // PUT: api/StudyMaterials/{id}
        [HttpPut("{id:guid}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> UpdateStudyMaterial(Guid id, CreateStudyMaterialDto dto)
        {
            var material = await _context.StudyMaterials.FindAsync(id);
            if (material == null) return NotFound();

            var userRole = User.FindFirstValue(ClaimTypes.Role);
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userRole == "Trainer" && material.TrainerId.ToString() != userIdStr)
                return Forbid();

            material.Title = dto.Title;
            material.Description = dto.Description;
            material.FileUrl = dto.FileUrl;

            await _context.SaveChangesAsync();
            return Ok(new { message = "Study material updated successfully" });
        }

        // DELETE: api/StudyMaterials/{id}
        [HttpDelete("{id:guid}")]
        [Authorize(Roles = "Admin,Trainer")]
        public async Task<IActionResult> DeleteStudyMaterial(Guid id)
        {
            var material = await _context.StudyMaterials.FindAsync(id);
            if (material == null) return NotFound();

            var userRole = User.FindFirstValue(ClaimTypes.Role);
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userRole == "Trainer" && material.TrainerId.ToString() != userIdStr)
                return Forbid();

            _context.StudyMaterials.Remove(material);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Study material deleted successfully" });
        }
    }
}
