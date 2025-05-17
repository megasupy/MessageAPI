using api.Models;
using api.Services;
using Microsoft.EntityFrameworkCore;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Load .env file (optional, for local dev)
DotNetEnv.Env.Load(); // requires DotNetEnv NuGet package

// Set connection using env. Crash if we don't have one.
string connectionString = Environment.GetEnvironmentVariable("PG_MESSAGES_CONNECTION_STRING") 
    ?? throw new InvalidOperationException("Missing environment variable: PG_MESSAGES_CONNECTION_STRING");

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseNpgsql(connectionString));

// Register the repository services (ensure this matches your actual repository class)
builder.Services.AddScoped<IRepository<Message, Guid>, MessageRepository>();

// CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi(); // Show errors to end user when in development mode.

}
app.UseHttpsRedirection(); // make sure you have ssl set up.
app.UseCors("AllowAll");
app.MapControllers();

app.Run();