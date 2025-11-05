using BarberShop.Application.DTO;
using MediatR;

namespace BarberShop.Application.Request.Service;

public record ListServicesRequest() : IRequest<Result<List<ServiceDto>>>;