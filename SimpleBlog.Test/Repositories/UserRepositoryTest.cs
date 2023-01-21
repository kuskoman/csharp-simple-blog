using SimpleBlog.Repositories.Interfaces;
using SimpleBlog.Repositories;
using SimpleBlog.Database;
using SimpleBlog.Models;
using SimpleBlog.Test.Repositories.Utils;
using Microsoft.EntityFrameworkCore;

namespace SimpleBlog.Test.Repositories
{
    public class UserRepositoryTest : IClassFixture<DbContextFixture>
    {
        private readonly BlogContext _context;
        private readonly IUserRepository _repository;

        public UserRepositoryTest(DbContextFixture fixture)
        {
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
            foreach (var user in users)
            {
                _repository.Create(user);
            }

            Assert.Equal(_repository.GetAll(), users);
        }
    }
}
