using BarberShop.Domain.Entity.Base;

namespace BarberShop.Domain.Entity;

public record Service(Guid Id, DateTime CreatedAt, DateTime UpdatedAt, string Name, decimal Price, TimeSpan Duration, bool Active)
    : BaseEntity(Id, CreatedAt, UpdatedAt);