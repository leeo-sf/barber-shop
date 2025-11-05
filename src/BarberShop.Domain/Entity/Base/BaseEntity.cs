namespace BarberShop.Domain.Entity.Base;

public record BaseEntity(Guid Id, DateTime CreatedAt, DateTime UpdatedAt)
{
    public Guid Id { get; init; } = Id;
    public DateTime CreatedAt { get; init; } = CreatedAt;
    public DateTime UpdatedAt { get; init; } = UpdatedAt;
}