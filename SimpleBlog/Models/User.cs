using Microsoft.AspNetCore.Identity;

namespace SimpleBlog.Models
{
    public class User : IdentityUser<uint>
    {
        public string? Name { get; set; }
        public string? PasswordDigest { get; set; }
    }
}
