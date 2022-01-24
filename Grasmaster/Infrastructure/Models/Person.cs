using System.ComponentModel.DataAnnotations;

namespace Grasmaster.Infrastructure.Models
{
	public abstract class Person
	{
		[Key]
		[Required]
		public ulong Id { get; set; }
		public string Name { get; set; } = default!;
	}
}
