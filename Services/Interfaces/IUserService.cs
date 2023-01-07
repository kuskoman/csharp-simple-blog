using SimpleBlog.Models;
using SimpleBlog.Dto;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        public User? GetByEmail(string email);
    }
}
