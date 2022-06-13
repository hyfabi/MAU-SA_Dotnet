namespace At.Mausa.Grasmaster.Domain.Models.Domain {
	public class Product : Entity
	{
		public Product(Guid? guid) : base(guid){}

		public string Description { get; set; } = "";
		public string Name { get; set; } = "";

		public void UpdateName(string name)
		{
			if (string.IsNullOrEmpty(name?.Trim()))
				throw new ArgumentException("Name is null or Empty!");
			Name = name;
		}

		public void UpdateDescription(string description)
		{
			if (string.IsNullOrEmpty(description?.Trim()))
				throw new ArgumentException("Description is null or Empty!");
			Description = description;
		}
	}
}
