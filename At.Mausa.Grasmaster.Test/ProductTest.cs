using At.Mausa.Grasmaster.Domain.Models;
using At.Mausa.Grasmaster.Infrastructure.Context;
using At.Mausa.Grasmaster.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Xunit;
using System.Threading.Tasks;

namespace At.Mausa.Grasmaster.Test
{
    public class ProductTest
    {
        [Fact]
        public async Task Test()
        {
            var db = getDbContext();
            ProductService service = new ProductService(db);
            Assert.True(service.GetProducts(10).ToList().Count() > 0);
        }

        private ApplicationDbContext getDbContext()
        {
            var options = new DbContextOptionsBuilder().UseSqlite("Data Source=TestAdministrator.db");
            var db = new ApplicationDbContext(options.Options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Product p = new Product(Guid.NewGuid());
            p.Name = "Grünes Gras";
            p.Description = "Das Gras ist immer Grün auf der anderen Seite";
            db.Products.Add(p);
            db.SaveChanges();
            return db;
        }
    }
}