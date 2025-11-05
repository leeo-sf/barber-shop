using MediatR;

namespace BarberShop.Application.Request.Service;

public record UpdateServiceRequest(Guid Id, string Name, decimal Price, int DurationInMinutes, bool Active) : IRequest<Result>;