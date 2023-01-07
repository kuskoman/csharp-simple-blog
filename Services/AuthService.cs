using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;

        public AuthService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Signup(UserCreateDto userDto)
        {
            var user = new User() { Email = userDto.Email, UserName = userDto.Name };

            if (userDto.Password == null)
            {
                throw new Exception("User DTO not validated properly: missing password");
            }
            return await _userManager.CreateAsync(user, userDto.Password);
        }
    }
}
