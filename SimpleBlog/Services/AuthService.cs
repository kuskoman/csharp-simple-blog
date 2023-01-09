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
        private readonly IUserService _userService;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IUserService userService
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        public async Task<IdentityResult> Signup(UserCreateDto userDto)
        {
            var user = new User() { Email = userDto.Email, UserName = userDto.Name };

            if (userDto.Password == null)
            {
                throw new ArgumentNullException("User DTO not validated properly: missing password");
            }
            return await _userManager.CreateAsync(user, userDto.Password);
        }

        public async Task<SignInResult> Login(UserLoginDto loginDto)
        {
            if (loginDto.Email == null)
            {
                throw new ArgumentNullException("Login DTO not validated properly: missing email");
            }
            var loginUser = _userService.GetByEmail(loginDto.Email);
            if (loginUser == null)
            {
                throw new UnauthorizedAccessException("Invalid user email");
            }

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

        public async Task Signout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
