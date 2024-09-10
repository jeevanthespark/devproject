using CleanArchitecture.MyShop.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.MyShop.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ProductDbContext>(options => options.UseInMemoryDatabase("MyShop"));
            services.AddScoped<IProductDbContext, ProductDbContext>();
            return services;
        }
    }
}
