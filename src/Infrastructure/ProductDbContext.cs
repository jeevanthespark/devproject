using CleanArchitecture.MyShop.Application.Common.Interfaces;
using CleanArchitecture.MyShop.Domain.Common;
using CleanArchitecture.MyShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.MyShop.Infrastructure;

[ExcludeFromCodeCoverage]
public class ProductDbContext : DbContext, IProductDbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }
    public DbSet<Product> Products { get; set; }
    public DbSet<Stock> Stocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var addedEntities = ChangeTracker.Entries<BaseAuditEntity>()
                                        .Where(e => e.State == EntityState.Added)
                                        .ToList();
        addedEntities.ForEach(entity =>
        {
            entity.Property(x => x.Created).CurrentValue = DateTime.UtcNow;
            entity.Property(x => x.Created).IsModified = true;
        });

        var modifiedEntities = ChangeTracker.Entries<BaseAuditEntity>()
                                            .Where(e => e.State == EntityState.Modified)
                                            .ToList();
        modifiedEntities.ForEach(entity =>
        {
            entity.Property(x => x.Updated).CurrentValue = DateTime.UtcNow;
            entity.Property(x => x.Updated).IsModified = true;
        });

        return base.SaveChangesAsync(true, cancellationToken);
    }
}
