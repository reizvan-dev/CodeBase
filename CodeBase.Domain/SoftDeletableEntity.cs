namespace CodeBase.Domain
{
    public class SoftDeletableEntity
    {

        public DateTime? DeleteTimeUTC { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}

