using CleanArchitecture.MyShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.MyShop.Infrastructure.EntityConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.Description)
                .IsRequired();
            builder.HasOne(x => x.Stock);
        }
    }
}
