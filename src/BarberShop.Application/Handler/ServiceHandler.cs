using AutoMapper;
using BarberShop.Application.DTO;
using BarberShop.Application.Request.Service;
using BarberShop.Domain.Interface;
using MediatR;

namespace BarberShop.Application.Handler;

public class ServiceHandler
    : IRequestHandler<CreateServiceRequest, Result>,
        IRequestHandler<ListServicesRequest, Result<List<ServiceDto>>>,
        IRequestHandler<DeleteServiceRequest, Result>,
        IRequestHandler<UpdateServiceRequest, Result>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IMapper _mapper;
    private const string SERVICE_NOT_FOUND = "Service not found";

    public ServiceHandler(
        IServiceRepository serviceRepository,
        IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _mapper = mapper;
    }

    public async Task<Result> Handle(CreateServiceRequest request, CancellationToken cancellationToken)
    {
        await _serviceRepository.CreateServiceAsync(
            new(Guid.NewGuid(), DateTime.UtcNow, DateTime.UtcNow, request.Name, request.Price, TimeSpan.FromMinutes(request.DurationInMinutes), false), cancellationToken);
        return Result.Ok();
    }

    public async Task<Result<List<ServiceDto>>> Handle(ListServicesRequest request, CancellationToken cancellationToken)
    {
        var services = await _serviceRepository.ListAllServicesAsync(cancellationToken);
        return Result<List<ServiceDto>>.Ok(_mapper.Map<List<ServiceDto>>(services));
    }

    public async Task<Result> Handle(DeleteServiceRequest request, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(request.Id, cancellationToken);
        if (service is null)
            return Result.Fail(new KeyNotFoundException(SERVICE_NOT_FOUND));

        if (service.Active)
            return Result.Fail(new InvalidOperationException("Cannot delete an active service"));

        // Avaliar melhor alternativa (Se o serviço mesmo desativado tiver agendamento ele não poderá ser excluído)
        await _serviceRepository.DeleteServiceAsync(service, cancellationToken);
        return Result.Ok();
    }

    public async Task<Result> Handle(UpdateServiceRequest request, CancellationToken cancellationToken)
    {
        var service = await _serviceRepository.GetServiceByIdAsync(request.Id, cancellationToken);
        if (service is null)
            return Result.Fail(new KeyNotFoundException(SERVICE_NOT_FOUND));

        await _serviceRepository.UpdateServiceAsync(
            new(service.Id, service.CreatedAt, DateTime.UtcNow, request.Name, request.Price, TimeSpan.FromMinutes(request.DurationInMinutes), request.Active), cancellationToken);
        return Result.Ok();
    }
}