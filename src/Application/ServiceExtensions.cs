using CleanArchitecture.MyShop.Application.Interfaces;
using CleanArchitecture.MyShop.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.MyShop.Application;

[ExcludeFromCodeCoverage]
public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();
        return services;
    }
}
