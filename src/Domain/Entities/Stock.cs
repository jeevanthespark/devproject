using CleanArchitecture.MyShop.Domain.Common;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.MyShop.Domain.Entities;

[ExcludeFromCodeCoverage]
public class Stock : BaseAuditEntity
{
    public int Id { get; set; }
    public int PurchasedQuantity { get; set; }
    public int RemainingQuantity { get; set; }
}
