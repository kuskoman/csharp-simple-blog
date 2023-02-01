using SimpleBlog.Database;
using SimpleBlog.Models;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BlogContext ctx) : base(ctx, ctx.Users!) { }

        public User? GetByEmail(string email)
        {
            return _dbSet.Where(u => u.Email == email).SingleOrDefault();
        }

        public User? GetByName(string name)
        {
            return _dbSet.Where(u => u.UserName == name).SingleOrDefault();
        }
    }
}
