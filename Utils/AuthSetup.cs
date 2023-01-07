using Microsoft.AspNetCore.Identity;
using SimpleBlog.Models;
using SimpleBlog.Database;

namespace SimpleBlog.Utils
{
    public static class AuthSetupUtil
    {
        public static void SetupAuth(WebApplicationBuilder builder)
        {
            builder.Services.AddDistributedMemoryCache();

            builder.Services
                .AddIdentity<User, Role>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1.0);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                })
                .AddEntityFrameworkStores<BlogContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddSession();
        }
    }
}
