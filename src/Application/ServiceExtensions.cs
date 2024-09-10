using CleanArchitecture.MyShop.Application.Interfaces;
using CleanArchitecture.MyShop.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.MyShop.Application
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            return services;
        }
    }
}
