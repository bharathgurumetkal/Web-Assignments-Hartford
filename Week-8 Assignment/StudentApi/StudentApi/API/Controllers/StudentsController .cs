using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApi.Domain.Entities;
using StudentApi.Infrastructure.Data;

namespace StudentApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // All endpoints require login
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // GET ALL STUDENTS
        // Roles: Admin, Trainer, Student
        // =========================
        [Authorize(Roles = "Admin,Trainer,Student")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            var students = await _context.Students.ToListAsync();
            return Ok(students);
        }

        // =========================
        // GET STUDENT BY ID
        // Roles: Admin, Trainer, Student
        // =========================
        [Authorize(Roles = "Admin,Trainer,Student")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound(new { message = "Student not found" });

            return Ok(student);
        }

        // =========================
        // CREATE STUDENT
        // Roles: Admin only
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Student>> CreateStudent(Student student)
        {
            student.Id = Guid.NewGuid();

            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStudent),
                new { id = student.Id }, student);
        }

        // =========================
        // UPDATE STUDENT
        // Roles: Admin, Trainer
        // =========================
        [Authorize(Roles = "Admin,Trainer")]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateStudent(Guid id, Student updatedStudent)
        {
            if (id != updatedStudent.Id)
                return BadRequest(new { message = "ID mismatch" });

            var existingStudent = await _context.Students.FindAsync(id);

            if (existingStudent == null)
                return NotFound(new { message = "Student not found" });

            // Update fields
            existingStudent.Name = updatedStudent.Name;
            existingStudent.Age = updatedStudent.Age;
            existingStudent.Email = updatedStudent.Email;
            existingStudent.Course = updatedStudent.Course;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Student updated successfully" });
        }

        // =========================
        // DELETE STUDENT
        // Roles: Admin only
        // =========================
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
                return NotFound(new { message = "Student not found" });

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Student deleted successfully" });
        }
    }
}
