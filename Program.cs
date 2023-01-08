using SimpleBlog.Database;
using SimpleBlog.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMyDependencyGroup();
builder.Services.AddControllers();
builder.Services.AddSqlite<BlogContext>("Data Source=blog.db;Cache=Shared");
builder.Services.AddEndpointsApiExplorer();

AuthSetupUtil.BuildAuth(builder);
SwaggerSetupUtil.BuildSwagger(builder);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    SwaggerSetupUtil.SetupSwaggerUi(app);
}

AuthSetupUtil.SetupAppAuth(app);

app.MapControllers();
app.Run();
