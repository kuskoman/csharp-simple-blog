using SimpleBlog.Database;
using SimpleBlog.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMyDependencyGroup();
builder.Services.AddControllers();
builder.Services.AddSqlServer<BlogContext>(builder.Configuration.GetConnectionString("Database"));
builder.Services.AddEndpointsApiExplorer();

AuthSetupUtil.BuildAuth(builder);
SwaggerSetupUtil.BuildSwagger(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    SwaggerSetupUtil.SetupSwaggerUi(app);
}

app.MapControllers();
app.Run();
