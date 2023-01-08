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
                    options.Password.RequiredLength = 7;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredUniqueChars = 0;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;

                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1.0);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<BlogContext>()
                .AddDefaultTokenProviders();
            builder.Services.AddSession();
        }
    }
}
