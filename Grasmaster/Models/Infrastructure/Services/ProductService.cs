using Grasmaster.Infrastructure.Context;
using Grasmaster.Infrastructure.Models;
using Grasmaster.Infrastructure.Services.Interfaces;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Grasmaster.Infrastructure.Services
{
	public class ProductService : IProductService
	{
		private ApplicationDbContext _applicationDbContext;

		public ProductService(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

        public Product CreateProduct(Product product)
        {
            Product p = _applicationDbContext.Products.Add(product).Entity;
            _applicationDbContext.SaveChanges();
            return p;
        }

        public Product DeleteProdukt(Product product)
        {
            if (!_applicationDbContext.Products.Contains(product))
                throw new ArgumentException("Product not found");
            Product p = _applicationDbContext.Products.Remove(product).Entity;
            _applicationDbContext.SaveChanges();
            return p;
        }

        public IReadOnlyList<Product> GetProducts()
        {
            return _applicationDbContext.Products.ToList();
        }

        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public Product UpdateProduct(Product product)
        {
            if (!_applicationDbContext.Products.Contains(product))
                throw new ArgumentException("Product not found");
            
            Product p = _applicationDbContext.Products.Update(product).Entity;
            _applicationDbContext.SaveChanges();
            return p;
        }
    }
}
