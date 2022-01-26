using System.ComponentModel.DataAnnotations;

namespace Grasmaster.Infrastructure.Models
{
	public abstract class Person : Entity
	{
        [Required]
        public string Name { get; set; } = "";

        protected Person(Guid? guid, string name) : base(guid)
        {
            Name = name;
        }
	}
}
