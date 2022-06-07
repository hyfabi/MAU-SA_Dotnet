namespace Grasmaster.Infrastructure.Models
{
	public class User : Person
	{
		public User(Guid? guid, string name) : base(guid, name)
		{
			
		}
		
		public ulong CartId { get; set; }
		public virtual Cart? Cart { get; set; }
	}
}
