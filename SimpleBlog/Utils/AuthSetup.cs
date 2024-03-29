using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using SimpleBlog.Models;
using SimpleBlog.Database;
using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SimpleBlog.Utils
{
    public static class AuthSetupUtil
    {
        public static void BuildAuth(WebApplicationBuilder builder)
        {
            var services = builder.Services;
            services.AddDistributedMemoryCache();

            services
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

            services.AddAuthentication();
            services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(7);
            });
            services.AddHttpContextAccessor();
            services.ConfigureApplicationCookie(options =>
            {
                options.Events.OnRedirectToLogin = ctx =>
                    HandleRedirect(ctx, HttpStatusCode.Unauthorized);
                options.Events.OnRedirectToLogout = ctx =>
                    HandleRedirect(ctx, HttpStatusCode.Unauthorized);
                options.Events.OnRedirectToAccessDenied = ctx =>
                    HandleRedirect(ctx, HttpStatusCode.Forbidden);
                options.Events.OnRedirectToReturnUrl = ctx =>
                    HandleRedirect(ctx, HttpStatusCode.Unauthorized);
            });

            services.AddCors(
                o =>
                    o.AddPolicy(
                        "MyOriginPolicy",
                        builder =>
                        {
                            // todo: dynamically add origins
                            builder.WithOrigins("http://localhost:5000");
                            builder.WithOrigins("http://localhost:8080");
                            builder.AllowCredentials();
                            builder.AllowAnyHeader();
                        }
                    )
            );
        }

        private static Task<int> HandleRedirect(
            RedirectContext<CookieAuthenticationOptions> ctx,
            HttpStatusCode code
        )
        {
            ctx.Response.StatusCode = (int)code;
            ctx.Response.WriteAsync("{\"error\": " + code + "}");
            return Task.FromResult(0);
        }
    }
}
