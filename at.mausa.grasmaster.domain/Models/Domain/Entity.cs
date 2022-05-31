using System.ComponentModel.DataAnnotations;

namespace Grasmaster.Infrastructure.Models
{
	public abstract class Entity
	{
		[Key]
		[Required]
		public ulong Id { get; init; }

		public Guid? Guid { get; set; }

		protected Entity(Guid? guid)
		{
			Guid = guid;
		}
	}
}
