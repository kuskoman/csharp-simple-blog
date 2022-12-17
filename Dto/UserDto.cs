using SimpleBlog.Models;
using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Dto
{
    public class UserCreateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }

    public class UserLoginDto
    {
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
