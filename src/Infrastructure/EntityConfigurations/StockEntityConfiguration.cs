using CleanArchitecture.MyShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.MyShop.Infrastructure.EntityConfigurations;

[ExcludeFromCodeCoverage]
public class StockEntityConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.RemainingQuantity)
            .IsRequired();
        builder.Property(x => x.PurchasedQuantity);
    }
}
