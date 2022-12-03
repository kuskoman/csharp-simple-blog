using SimpleBlog.Database;
using SimpleBlog.Models;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogContext _blogContext;

        public UserRepository(BlogContext ctx)
        {
            _blogContext = ctx;
        }

        public List<User> GetAll()
        {
            return _blogContext.Users.ToList();
        }

        public User? Get(int id)
        {
            return _blogContext.Users.Find(id);
        }

        public User Delete(int id)
        {
            var dbUser = _blogContext.Users.Find(id);
            if (dbUser == null)
            {
                throw new ArgumentException($"Could not find user with id ${id}");
            }

            _blogContext.Remove(dbUser);
            _blogContext.SaveChanges();

            return dbUser;
        }

        public User Create(User user)
        {
            _blogContext.Users.Add(user);
            _blogContext.SaveChanges();
            return user;
        }

        public User Modify(User newUser)
        {
            var oldUser = _blogContext.Users.Find(newUser);
            if (oldUser == null)
            {
                throw new ArgumentException("Could not find user with given id");
            }

            _blogContext.Entry(oldUser).CurrentValues.SetValues(newUser);
            _blogContext.SaveChanges();
            return newUser;
        }
    }
}
