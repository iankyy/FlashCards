namespace Backend.Data.Entities
{
    public class BaseEntity
    {
        public DateTime Created_At { get; set; } = DateTime.Now;
        public DateTime Updated_At { get; set; } = default!;
    }
}
