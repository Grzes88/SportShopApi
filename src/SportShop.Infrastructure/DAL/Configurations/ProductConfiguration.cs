using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportShop.Core.Entities;
using SportShop.Core.ValueObjects;

namespace SportShop.Infrastructure.DAL.Configurations;

internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasConversion(pid => pid.Value, g => new ProductId(g));
        builder.Property(p => p.Name)
            .HasConversion(n => n.Value, s => new Name(s));
    }
}