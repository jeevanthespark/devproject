namespace CleanArchitecture.MyShop.Domain.Common
{
    public class BaseAuditEntity
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
