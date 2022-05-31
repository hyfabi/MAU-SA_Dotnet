namespace Grasmaster.Infrastructure.Models
{
    public class Cart : Entity
    {
        public Cart(Guid? guid) : base(guid)
        {}

        public virtual User User { get; set; }
        public ulong UserId { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}