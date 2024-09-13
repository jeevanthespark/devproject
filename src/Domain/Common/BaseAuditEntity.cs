using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.MyShop.Domain.Common;

[ExcludeFromCodeCoverage]
public class BaseAuditEntity
{
    public DateTime Created { get; set; }
    public DateTime? Updated { get; set; }
}
