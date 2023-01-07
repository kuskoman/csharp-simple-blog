using SimpleBlog.Dto;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<IdentityResult> Signup(UserCreateDto model);
    }
}
