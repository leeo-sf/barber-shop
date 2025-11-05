using BarberShop.Domain.Entity;

namespace BarberShop.Domain.Interface;

public interface IServiceRepository
{
    Task CreateServiceAsync(Service service, CancellationToken cancellationToken);
    Task<List<Service>> ListAllServicesAsync(CancellationToken cancellationToken);
    Task<Service?> GetServiceByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task DeleteServiceAsync(Service service, CancellationToken cancellationToken);
    Task UpdateServiceAsync(Service service, CancellationToken cancellationToken);
}