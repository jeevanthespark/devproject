using CleanArchitecture.MyShop.Application.Common.Interfaces;
using CleanArchitecture.MyShop.Application.Interfaces;
using CleanArchitecture.MyShop.Domain.Entities;
using CleanArchitecture.MyShop.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.MyShop.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductDbContext _context;
        public ProductService(IProductDbContext productDbContext)
        {
            _context = productDbContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var prd = await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return prd.Entity;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var result = await _context.Products
                                .Include(x => x.Stock)
                                .ToListAsync();
            return result.Count == 0 ? throw new ResourceNotFoundException("No products found") : result;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products
                                .Include(x => x.Stock)
                                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new ResourceNotFoundException("No products found");
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var entity = await _context.Products
                                    .Include(x => x.Stock)
                                    .FirstOrDefaultAsync(x => x.Id == product.Id);
            if (entity != null)
            {
                PoulateProductEntity(product, entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        private static void PoulateProductEntity(Product product, Product entity)
        {
            entity.Description = product.Description;
            entity.Name = product.Name;
            entity.Stock.PurchasedQuantity = product.Stock.PurchasedQuantity;
            entity.Stock.RemainingQuantity = product.Stock.RemainingQuantity;
        }
    }
}
