using BarberShop.Domain.Entity;
using BarberShop.Domain.Interface;
using Microsoft.EntityFrameworkCore;

namespace BarberShop.Data.Repository;

public class ServiceRepository : IServiceRepository
{
    private readonly AppDbContext _context;

    public ServiceRepository(AppDbContext context)
        => _context = context;

    public async Task CreateServiceAsync(Service service, CancellationToken cancellationToken)
    {
        await _context.Service.AddAsync(service, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Service>> ListAllServicesAsync(CancellationToken cancellationToken)
        => await _context.Service
            .AsNoTracking()
            .Where(opt => opt.Active)
            .ToListAsync(cancellationToken);

    public async Task<Service?> GetServiceByIdAsync(Guid Id, CancellationToken cancellationToken)
        => await _context.Service
            .AsNoTracking()
            .FirstOrDefaultAsync(opt => opt.Id == Id, cancellationToken);

    public async Task DeleteServiceAsync(Service service, CancellationToken cancellationToken)
    {
        _context.Service.Remove(service);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateServiceAsync(Service service, CancellationToken cancellationToken)
    {
        _context.Service.Update(service);
        await _context.SaveChangesAsync(cancellationToken);
    }
}