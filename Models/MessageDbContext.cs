using Microsoft.EntityFrameworkCore;
namespace api.Models;

public class MessageDbContext : DbContext
{
    public DbSet<Message> Messages { get; set; }

    public MessageDbContext(DbContextOptions options) : base(options)
    {
    }
}