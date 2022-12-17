using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;

namespace SimpleBlog.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        protected new readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public User? GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
    }
}
