namespace Grasmaster.Infrastructure.Models
{
	public abstract class Person
	{
		public ulong Id { get; set; }
		public string Name { get; set; } = default!;
	}
}
