using Microsoft.OpenApi.Models;

namespace SimpleBlog.Utils
{
    public static class SwaggerSetupUtil
    {
        public static void BuildSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo() { Title = "SimpleBlog", Version = "v1" });
            });
        }

        public static void SetupSwaggerUi(WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
