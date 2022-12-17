using SimpleBlog.Models;
using SimpleBlog.Dto;

namespace SimpleBlog.Services.Interfaces
{
    public interface IAuthService
    {
        public User Register(UserCreateDto dto);
        public User Authenticate(UserLoginDto dto);
    }
}
