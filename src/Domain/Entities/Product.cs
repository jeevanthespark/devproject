using CleanArchitecture.MyShop.Domain.Common;

namespace CleanArchitecture.MyShop.Domain.Entities
{
    public class Product : BaseAuditEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
