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
        [Required]
        public string Email { get; } = string.Empty;

        [Required]
        public string Name { get; } = string.Empty;

        [Required]
        public uint Id { get; } = 0;
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
