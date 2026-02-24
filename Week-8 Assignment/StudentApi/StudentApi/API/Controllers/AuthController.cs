using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StudentApi.Application.DTOs.Auth;
using StudentApi.Domain.Entities;
using StudentApi.Infrastructure.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StudentApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        // =====================
        // POST api/auth/register
        // =====================
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(x => x.Email == dto.Email))
                return BadRequest(new { message = "User with this email already exists." });

            var user = new AppUser
            {
                Id = Guid.NewGuid(),
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully." });
        }

        // =====================
        // POST api/auth/login
        // =====================
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email.ToLower() == dto.Email.ToLower());

            if (user == null)
                return Unauthorized(new { message = "Login failed: No account found with this email." });

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return Unauthorized(new { message = "Login failed: Incorrect password." });

            var token = GenerateJwtToken(user);

            return Ok(new
            {
                token,
                id = user.Id,
                username = user.Username,
                role = user.Role,
                email = user.Email
            });
        }

        // =====================
        // JWT Token Generator
        // =====================
        private string GenerateJwtToken(AppUser user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,           user.Username),
                new Claim(ClaimTypes.Email,          user.Email),
                new Claim(ClaimTypes.Role,           user.Role)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:             _configuration["Jwt:Issuer"],
                audience:           _configuration["Jwt:Audience"],
                claims:             claims,
                expires:            DateTime.UtcNow.AddMinutes(
                                        Convert.ToDouble(_configuration["Jwt:DurationInMinutes"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}