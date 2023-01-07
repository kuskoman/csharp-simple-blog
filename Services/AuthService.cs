using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task<SignInResult> Login(UserLoginDto loginDto)
        {
            var loginUser = new User() { Email = loginDto.Email };
            if (loginDto.Password == null)
            {
                throw new Exception("User DTO not validated properly: missing password");
            }
            return await _signInManager.PasswordSignInAsync(
                loginUser,
                loginDto.Password,
                true,
                true
            );
        }
    }
}
