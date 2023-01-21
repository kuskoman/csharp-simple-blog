using Microsoft.AspNetCore.Identity;
using SimpleBlog.Models.Interfaces;

namespace SimpleBlog.Models
{
    public class Role : IdentityRole<uint>, IModel { }
}
