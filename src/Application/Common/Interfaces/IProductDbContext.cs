using CleanArchitecture.MyShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.MyShop.Application.Common.Interfaces
{
    public interface IProductDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Stock> Stocks { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
