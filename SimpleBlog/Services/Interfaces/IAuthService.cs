using SimpleBlog.Dto;
using Microsoft.AspNetCore.Identity;
using SimpleBlog.Models;

namespace SimpleBlog.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<IdentityResult> Signup(UserCreateDto model);
        public Task<SignInResult> Login(UserLoginDto model);
        public Task Signout();
    }
}
