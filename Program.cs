using SimpleBlog.Database;
using SimpleBlog.Utils;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMyDependencyGroup();
builder.Services.AddControllers();

AuthSetupUtil.SetupAuth(builder);

builder.Services.AddSqlite<BlogContext>("Data Source=blog.db;Cache=Shared");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

SwaggerSetupUtil.SetupSwagger(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
