using BarberShop.Data.EntityConfiguration;
using BarberShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Service> Service { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ServiceEntityConfiguration());
    }
}