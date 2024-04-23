using Microsoft.EntityFrameworkCore;
using SportShop.Core.Entities;

namespace SportShop.Infrastructure.DAL;

public sealed class SportShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public SportShopDbContext(DbContextOptions<SportShopDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}