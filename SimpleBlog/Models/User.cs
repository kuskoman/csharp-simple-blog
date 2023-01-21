using Microsoft.AspNetCore.Identity;
using SimpleBlog.Models.Interfaces;

namespace SimpleBlog.Models
{
    public class User : IdentityUser<uint>, IModel
    {
        public string? Name { get; set; }
        public string? PasswordDigest { get; set; }
    }
}
