using BarberShop.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BarberShop.Data.EntityConfiguration;

internal class ServiceEntityConfiguration : BaseEntityConfiguration<Service>
{
    public override void Configure(EntityTypeBuilder<Service> builder)
    {
        base.Configure(builder);

        builder.Property(s => s.Name).IsRequired().HasMaxLength(100).HasColumnName("name");
        builder.Property(s => s.Price).IsRequired().HasPrecision(6, 2).HasColumnName("price");
        builder.Property(s => s.Duration).IsRequired().HasColumnName("duration");
        builder.Property(s => s.Active).IsRequired().HasDefaultValue(false).HasColumnName("active");
    }
}