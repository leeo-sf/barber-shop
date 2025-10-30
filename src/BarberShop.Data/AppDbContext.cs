using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
}