using Grasmaster.Infrastructure.Models;

using Microsoft.EntityFrameworkCore;

namespace Grasmaster.Infrastructure.Context
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<User> User { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Cart> InCart { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				///TODO: ...
				optionsBuilder.UseSqlServer();
			}
		}

		public ApplicationDbContext(DbContextOptions dbContextOptions) : base (dbContextOptions)
		{}

		/// <summary>
		/// TODO: Edmond
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//Entity
			modelBuilder.Entity<Entity>(entity => {
				entity.HasKey((y) => y.Id);
				entity.Property(y => y.Id).ValueGeneratedOnAdd();
			});
			//Person
			modelBuilder.Entity<Person>(entity => entity.HasBaseType<Entity>());

			

			
			//Product
			modelBuilder.Entity<Product>((entity) =>
			{
				entity.HasBaseType<Entity>();
			});

			//InCart
			modelBuilder.Entity<Cart>((entity) =>
			{
				entity.HasBaseType<Entity>();
				entity.HasMany(x => x.Products);
				entity.HasOne(x => x.User);
			});

			//Address
			modelBuilder.Entity<Address>((entity) =>
			{
				entity.HasBaseType<Entity>();
			});

			//User
			modelBuilder.Entity<User>((entity) =>
			{
				entity.HasOne(x => x.Address);
				entity.HasBaseType<Person>();
				entity.HasOne(x => x.Cart)
				.WithOne(x => x.User)
				.HasForeignKey<User>(x => x.CartId);
			});
		}
	}
}
