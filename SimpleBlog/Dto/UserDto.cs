using System.ComponentModel.DataAnnotations;

using SimpleBlog.Models;

namespace SimpleBlog.Dto
{
    public class UserCreateDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(7)]
        public string? Password { get; set; }
    }

    public class UserLoginDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }

    public class UserResponseDto
    {
        public UserResponseDto(User user)
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

    public class AuthorResponseDto
    {
        public AuthorResponseDto(User user)
        {
            Name = user.UserName!;
            Id = user.Id!;
        }

        public string Name { get; }
        public uint Id { get; }
    }
}
