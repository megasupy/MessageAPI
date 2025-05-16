using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Load .env file (optional, for local dev)
DotNetEnv.Env.Load(); // requires DotNetEnv NuGet package

// Replace connection string manually from env
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

if (connectionString == null)
{
    throw new Exception("No environment variable for connection string found!");
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register the repository services (ensure this matches your actual repository class)
builder.Services.AddScoped<IRepository<Message, Guid>, MessageRepository>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();