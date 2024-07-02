namespace CodeBase.Domain
{
    public class AuditableEntity : SoftDeletableEntity
    {
        public DateTime? CreatedDateUTC { get; set; }
        public DateTime? ModifiedDateUTC { get; set; }
    }
}