using Microsoft.EntityFrameworkCore;
namespace api.Models;

public class SalesDbContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Message> Messages { get; set; }

    public SalesDbContext(DbContextOptions options) : base(options)
    {
    }
}