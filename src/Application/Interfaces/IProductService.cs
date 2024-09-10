using CleanArchitecture.MyShop.Domain.Entities;

namespace CleanArchitecture.MyShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
    }
}
