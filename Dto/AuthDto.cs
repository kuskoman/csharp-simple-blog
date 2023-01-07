using System.ComponentModel.DataAnnotations;
using SimpleBlog.Models;

namespace SimpleBlog.Dto
{
    public class AuthResultDto
    {
        public AuthResultDto(User user)
        {
            Email = user.Email!;
            Name = user.UserName!;
            Id = user.Id!;
        }

        [EmailAddress]
        public string Email { get; }

        public string Name { get; }
        public uint Id { get; }
    }
}
