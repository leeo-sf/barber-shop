using Asp.Versioning;
using BarberShop.Application;
using BarberShop.Data;
using BarberShop.Data.Repository;
using BarberShop.Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BarberShop.Infrastructure.Configuration;

public static class AppDependenciesConfiguration
{
    public static void ConfigDbContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseNpgsql(configuration["ConnectionStrings:Database"]);
        });

    public static void ConfigureMediator(this IServiceCollection services)
        => services.AddMediatR(opt =>
        {
            opt.RegisterServicesFromAssemblies(typeof(Result).Assembly);
        });

    public static void ConfigureApiVersioning(this IServiceCollection services)
        => services.AddApiVersioning(opt =>
        {
            opt.DefaultApiVersion = new ApiVersion(1, 0);
            opt.AssumeDefaultVersionWhenUnspecified = true;
            opt.ReportApiVersions = true;

            opt.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new QueryStringApiVersionReader("api-version"),
                new HeaderApiVersionReader("x-api-version"));
        })
        .AddApiExplorer(opt =>
        {
            opt.GroupNameFormat = "'v'VVV";
            opt.SubstituteApiVersionInUrl = true;
        });

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton(AutoMapperConfiguration.RegisterMaps().CreateMapper());

        services.AddScoped<IServiceRepository, ServiceRepository>();
    }
}