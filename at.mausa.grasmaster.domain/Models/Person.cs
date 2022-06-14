using System.ComponentModel.DataAnnotations;
using System.IO;

namespace At.Mausa.Grasmaster.Domain.Models {
    public abstract class Person : Entity {
        [Required]
        public string Name { get; set; } = "";

        public Address Address { get; set; } = default!;

        protected Person(Guid? guid, string name) : base(guid) {
            Name = name;
        }

        public void UpdateName(string name) {
            if(string.IsNullOrEmpty(name?.Trim()))
                throw new ArgumentException("Name is null or Empty!");
            Name = name;
        }

        public void UpdateAddress(Address address) => Address = address;

    }
}
