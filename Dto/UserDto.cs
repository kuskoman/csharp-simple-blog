using System.ComponentModel.DataAnnotations;

namespace SimpleBlog.Dto
{
    public class UserCreateDto
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Email { get; set; }

        /// <summary>
        /// A strong password that is already 7 characters long
        /// </summary>
        /// <example>AStrongPassword946!</example>
        [Required]
        [MinLength(7)]
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
