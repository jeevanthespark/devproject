using CleanArchitecture.MyShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.MyShop.Infrastructure.EntityConfigurations
{
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
}
