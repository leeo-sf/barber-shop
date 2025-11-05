using AutoMapper;
using BarberShop.Application.DTO;
using BarberShop.Domain.Entity;

namespace BarberShop.Infrastructure.Configuration;

public static class AutoMapperConfiguration
{
    public static MapperConfiguration RegisterMaps()
        => new MapperConfiguration(config =>
        {
            config.CreateMap<Service, ServiceDto>();
        });
}