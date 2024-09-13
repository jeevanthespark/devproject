using CleanArchitecture.MyShop.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.MyShop.Infrastructure;

[ExcludeFromCodeCoverage]
public static class ServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ProductDbContext>(options => options.UseInMemoryDatabase("MyShop"));
        services.AddScoped<IProductDbContext, ProductDbContext>();
        return services;
    }
}
