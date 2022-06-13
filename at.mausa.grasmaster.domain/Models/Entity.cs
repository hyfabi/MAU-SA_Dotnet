using System.ComponentModel.DataAnnotations;

namespace At.Mausa.Grasmaster.Domain.Models {
    public abstract class Entity {
        [Key]
        [Required]
        public ulong Id { get; init; }

        public Guid? Guid { get; set; }

        protected Entity(Guid? guid) {
            Guid = guid ?? System.Guid.NewGuid();
        }
    }
}
