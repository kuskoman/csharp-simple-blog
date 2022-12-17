using SimpleBlog.Models;
using SimpleBlog.Dto;

namespace SimpleBlog.Services.Interfaces
{
    public interface IUserService : IBaseService<User>
    {
        public User GetByEmail(string email);
    }
}
