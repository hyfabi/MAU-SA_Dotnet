namespace Grasmaster.Infrastructure.Models
{
	public class Product : Entity
	{
		public Product(Guid? guid) : base(guid){}

		public string Description { get; set; } = "";
		public string Name { get; set; } = "";
	}
}
