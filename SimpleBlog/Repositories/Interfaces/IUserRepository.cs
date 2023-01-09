using SimpleBlog.Models;

namespace SimpleBlog.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public User? GetByEmail(string email);
    }
}