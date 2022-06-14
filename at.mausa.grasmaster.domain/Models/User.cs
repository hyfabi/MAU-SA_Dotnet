namespace At.Mausa.Grasmaster.Domain.Models {
    public class User : Person {
        public User(Guid? guid, string name) : base(guid, name) {

        }

        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;

        public ulong? CartId { get; set; }
        public virtual Cart? Cart { get; set; }
    }
}
