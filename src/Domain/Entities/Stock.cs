using CleanArchitecture.MyShop.Domain.Common;

namespace CleanArchitecture.MyShop.Domain.Entities
{
    public class Stock : BaseAuditEntity
    {
        public int Id { get; set; }
        public int PurchasedQuantity { get; set; }
        public int RemainingQuantity { get; set; }
    }
}
