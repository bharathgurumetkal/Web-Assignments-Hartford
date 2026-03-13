using Authentication.Application.DTOs;
using Authentication.Application.Interfaces;
using Authentication.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IUserRepository userRepository, IMapper mapper)
        {
            _authService = authService;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto registerDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null) return BadRequest("Email already registered.");

            var user = _mapper.Map<User>(registerDto);
            var token = await _authService.RegisterAsync(user, registerDto.Password);

            return Ok(new AuthResponseDto
            {
                Token = token,
                User = _mapper.Map<UserDto>(user)
            });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto.Email, loginDto.Password);
            if (token == null) return Unauthorized("Invalid credentials.");

            var user = await _userRepository.GetByEmailAsync(loginDto.Email);
            return Ok(new AuthResponseDto
            {
                Token = token,
                User = _mapper.Map<UserDto>(user!)
            });
        }
    }
}
