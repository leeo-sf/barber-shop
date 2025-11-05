using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BarberShop.Infrastructure.Configuration;

public static class SwaggerConfiguration
{
    public static void ConfigureSwagger(this IServiceCollection services)
        => services.AddSwaggerGen(opt =>
        {
            opt.ConfigSwaggerDoc(services);
        });

    private static void ConfigSwaggerDoc(this SwaggerGenOptions options, IServiceCollection services)
    {
        var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, new OpenApiInfo
            {
                Title = "BarberShop API",
                Version = description.ApiVersion.ToString(),
                Description = "Barbershop scheduling and management API",
                Contact = new OpenApiContact
                {
                    Name = "Leonardo Ferreira",
                    Email = "leonardoferreira032@gmail.com",
                    Url = new Uri("https://github.com/leeo-sf/barber-shop")
                }
            });
        }
    }
}