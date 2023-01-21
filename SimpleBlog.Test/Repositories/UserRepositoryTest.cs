using SimpleBlog.Repositories.Interfaces;
using SimpleBlog.Repositories;
using SimpleBlog.Database;
using SimpleBlog.Models;
using SimpleBlog.Test.Repositories.Utils;

namespace SimpleBlog.Test.Repositories
{
    public class UserRepositoryTest
    {
        private readonly BlogContext _context;
        private readonly IUserRepository _repository;

        public UserRepositoryTest()
        {
            var fixture = new DbContextFixture();
            _context = fixture.Context;
            _repository = new UserRepository(_context);
        }

        [Fact]
        public void TestGetAll()
        {
            var users = new List<User>()
            {
                new User() { Id = 1 },
                new User() { Id = 2 }
            };

            CreateUsers(users);

            Assert.Equal(_repository.GetAll(), users);
        }

        [Fact]
        public void TestGet()
        {
            var choosenOne = new User() { Name = "Choosen one", Id = 2 };
            var users = new List<User>()
            {
                new User() { Id = 1 },
                choosenOne,
                new User() { Id = 3 }
            };

            CreateUsers(users);

            Assert.Equal(_repository.Get(choosenOne.Id), choosenOne);
        }

        private void CreateUsers(List<User> users)
        {
            foreach (var user in users)
            {
                _repository.Create(user);
            }
        }
    }
}
