using MediatR;

namespace BarberShop.Application.Request.Service;

public record CreateServiceRequest(string Name, decimal Price, int DurationInMinutes) : IRequest<Result>;