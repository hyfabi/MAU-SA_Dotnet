using Grasmaster.Infrastructure.Models;

using Microsoft.EntityFrameworkCore;

namespace Grasmaster.Infrastructure.Context
{
	public class ApplicationContext : DbContext
	{
		public DbSet<User> User { get; set; }
		public DbSet<Product> Products { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				///TODO: ...
				optionsBuilder.UseSqlServer();
			}
		}

		/// <summary>
		/// TODO: Edmond
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//User
			modelBuilder.Entity<User>((entity) =>
			{
				entity.HasIndex((x) => x.Id);
				entity.Property(x => x.Id).ValueGeneratedOnAddOrUpdate();
			});

			//Product
			modelBuilder.Entity<Product>((entity) =>
			{
				entity.HasIndex((x) => x.Id);
				entity.Property(x => x.Id).ValueGeneratedOnAddOrUpdate();
			});
		}
	}
}
