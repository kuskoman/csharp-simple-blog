using Microsoft.OpenApi.Models;

namespace SimpleBlog.Utils
{
    public static class SwaggerSetupUtil
    {
        public static void SetupSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "SimpleBlog", Version = "v1" });
            });
        }
    }
}
