using SimpleBlog.Database;
using SimpleBlog.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMyDependencyGroup();
builder.Services.AddControllers();

AuthSetupUtil.BuildAuth(builder);

builder.Services.AddSqlite<BlogContext>("Data Source=blog.db;Cache=Shared");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

SwaggerSetupUtil.BuildSwagger(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    SwaggerSetupUtil.SetupSwaggerUi(app);
}

AuthSetupUtil.SetupAppAuth(app);

app.MapControllers();

app.Run();
