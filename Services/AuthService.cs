using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;
using BC = BCrypt.Net.BCrypt;

namespace SimpleBlog.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserService userService, ILogger<AuthService> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public User Register(UserCreateDto dto)
        {
            var passwordDigest = BC.HashPassword(dto.Password);
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordDigest = passwordDigest,
                Role = UserRole.Commenter
            };

            return _userService.Create(user);
        }

        public User Authenticate(UserLoginDto dto)
        {
            var errorText = "Could not find user for given email and/or password";
            var email = dto.Email;
            if (email == null || email == "")
            {
                throw new ArgumentException("You must provide email to authenticate");
            }

            var user = _userService.GetByEmail(email);
            if (user == null)
            {
                _logger.LogError($"User failed to authenticate: no user found for email {email}");
                throw new ArgumentException(errorText);
            }

            var passwordValid = BC.Verify(dto.Password, user.PasswordDigest);
            if (!passwordValid)
            {
                _logger.LogError("User failed to authenticate");
                throw new ArgumentException(errorText);
            }

            return user;
        }
    }
}
