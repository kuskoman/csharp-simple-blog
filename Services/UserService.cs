using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User? Get(int id)
        {
            return _repository.Get(id);
        }

        public User? GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public User Delete(int id)
        {
            return _repository.Delete(id);
        }

        public User Create(User user)
        {
            return _repository.Create(user);
        }

        public User Modify(User user)
        {
            return _repository.Modify(user);
        }
    }
}
