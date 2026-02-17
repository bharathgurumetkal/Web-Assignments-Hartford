using BasicAuthentication.Data;
using BasicAuthentication.DTOs;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }


        //register
       [HttpPost("register")]
public IActionResult Register(CreateUserDto model)
{
 
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

 
    var existingUser = _context.Users
        .FirstOrDefault(u => u.Email == model.Email);

    if (existingUser != null)
        return BadRequest("User already exists with this email.");


    var objUser = new User
    {
        FirstName = model.FirstName,
        LastName = model.LastName,
        Email = model.Email,
        Password = model.Password, 
        IsActive = true,
        CreatedAt = DateTime.UtcNow
    };

 
    _context.Users.Add(objUser);
    _context.SaveChanges();


    return Ok("User registered successfully.");
}


        [HttpPost("login")]
        public IActionResult Login(LoginDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

          
            var objUser = _context.Users
                .FirstOrDefault(u => u.Email == model.Email && u.IsActive == true);

            if (objUser == null)
                return Unauthorized("Invalid email or user does not exist.");

       
            if (objUser.Password != model.Password)
                return Unauthorized("Invalid password.");

      
            return Ok(objUser);
        }



        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();

            if (users == null || users.Count == 0)
                return NotFound("No users found.");

            return Ok(users);
        }



    }
}
