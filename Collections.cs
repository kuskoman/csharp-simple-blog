using SimpleBlog.Services.Interfaces;
using SimpleBlog.Services;
using SimpleBlog.Repositories;
using SimpleBlog.Repositories.Interfaces;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MyServiceCollectionExtensions
    {
        public static IServiceCollection AddMyDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();

            return services;
        }
    }
}
