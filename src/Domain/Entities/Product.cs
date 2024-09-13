using CleanArchitecture.MyShop.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.MyShop.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Product : BaseAuditEntity
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required virtual Stock Stock { get; set; }
}
