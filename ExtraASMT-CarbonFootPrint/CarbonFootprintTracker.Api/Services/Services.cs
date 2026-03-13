using CarbonFootprintTracker.Api.Helpers;
using CarbonFootprintTracker.Api.Interfaces;
using CarbonFootprintTracker.Api.Models;

namespace CarbonFootprintTracker.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public AuthService(IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<string> RegisterAsync(User user, string password)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(password);
            await _userRepository.CreateAsync(user);
            return _jwtHelper.GenerateToken(user);
        }

        public async Task<string?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return _jwtHelper.GenerateToken(user);
        }
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByIdAsync(string id) => await _userRepository.GetByIdAsync(id);

        public async Task UpdateUserAsync(string id, User user) => await _userRepository.UpdateAsync(id, user);

        public async Task DeleteUserAsync(string id) => await _userRepository.DeleteAsync(id);
    }

}
