using MediatR;

namespace BarberShop.Application.Request.Service;

public record DeleteServiceRequest(Guid Id) : IRequest<Result>;