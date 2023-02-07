using SimpleBlog.Models;
using SimpleBlog.Services.Interfaces;
using SimpleBlog.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        protected new readonly IUserRepository _repository;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository repository, UserManager<User> userManager)
            : base(repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        public User? GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public User? GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<string> GetRoles(User user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            if (roles == null)
            {
                roles = new List<string>();
            }
            return roles.ToList();
        }
    }
}
