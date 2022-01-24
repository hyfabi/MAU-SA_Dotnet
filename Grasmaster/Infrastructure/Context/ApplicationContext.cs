using Grasmaster.Infrastructure.Models;

using Microsoft.EntityFrameworkCore;

namespace Grasmaster.Infrastructure.Context
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                ///TODO: ...
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<User>((entity) =>
			{
                entity.HasIndex((x) => x.Id);
			});
        }
    }
}
