using BarberShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Infrastructure;

public static class AppDependenciesConfig
{
    public static void ConfigDbContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration["ConnectionStrings:Database"]);
        });
}