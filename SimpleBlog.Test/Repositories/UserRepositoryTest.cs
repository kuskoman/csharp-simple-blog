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
        public void TestGetUserExists()
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

        [Fact]
        public void TestGetUserNotExist()
        {
            var users = new List<User>() { new User() { Id = 1 } };

            CreateUsers(users);

            Assert.Null(_repository.Get(99));
        }

        private void CreateUsers(List<User> users)
        {
            foreach (var user in users)
            {
                _repository.Create(user);
            }
        }

        [Fact]
        public void TestDeleteUserExists()
        {
            var userToDelete = new User() { Id = 2 };
            var users = new List<User>()
            {
                new User() { Id = 1 },
                userToDelete,
                new User() { Id = 3 }
            };

            CreateUsers(users);

            Assert.Equal(_repository.Delete(userToDelete.Id), userToDelete);
            Assert.DoesNotContain(userToDelete, _repository.GetAll());
        }

        [Fact]
        public void TestDeleteUserNotExist()
        {
            var users = new List<User>() { new User() { Id = 1 } };

            CreateUsers(users);

            Assert.Throws<ArgumentException>(() => _repository.Delete(99));
        }

        [Fact]
        public void TestCreateUser()
        {
            var newUser = new User() { Id = 2 };
            _repository.Create(newUser);

            Assert.Contains(newUser, _repository.GetAll());
        }

        [Fact]
        public void TestModifyUserExists()
        {
            var userToModify = new User() { Id = 2, Name = "Original name" };
            var userUpdateModel = new User() { Id = userToModify.Id, Name = "Modified name" };
            var users = new List<User>()
            {
                new User() { Id = 1 },
                userToModify
            };

            CreateUsers(users);

            var updatedUser = _repository.Modify(userUpdateModel);

            Assert.Equal(updatedUser.Id, userToModify.Id);
            Assert.Equal(updatedUser.Email, userUpdateModel.Email);

            var reloadedModel = _repository.Get(userToModify.Id);
            Assert.NotNull(reloadedModel);
            Assert.Equal(reloadedModel.Id, updatedUser.Id);
            Assert.Equal(reloadedModel.Name, updatedUser.Name);
        }

        [Fact]
        public void TestModifyUserNotExist()
        {
            var userToModify = new User() { Id = 99, Name = "Modified name" };

            Assert.Throws<ArgumentException>(() => _repository.Modify(userToModify));
        }

        [Fact]
        public void TestGetByEmailExist()
        {
            var user = new User() { Email = "test@example.com", Id = 2 };
            var users = new List<User>()
            {
                new User() { Id = 1 },
                user
            };

            CreateUsers(users);

            Assert.Equal(_repository.GetByEmail(user.Email), user);
        }

        [Fact]
        public void TestGetByEmailNotExist()
        {
            var users = new List<User>() { new User() { Id = 1 } };

            CreateUsers(users);

            Assert.Null(_repository.GetByEmail("nonexistent@example.com"));
        }
    }
}
