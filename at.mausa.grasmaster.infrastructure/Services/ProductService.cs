

using At.Mausa.Grasmaster.Domain.Models;
using At.Mausa.Grasmaster.Infrastructure.Context;
using At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace At.Mausa.Grasmaster.Infrastructure.Services {
	public class ProductService : IProductService
	{
		private ApplicationDbContext _applicationDbContext;

		public ProductService(ApplicationDbContext applicationDbContext) => _applicationDbContext = applicationDbContext;

		public Product CreateProduct(Product product)
		{
			Product p = _applicationDbContext.Products.Add(product).Entity;
			p.Guid = Guid.NewGuid();
			_applicationDbContext.SaveChanges();
			return p;
		}

		public Product DeleteProduct(Guid product)
		{
			if (!_applicationDbContext.Products.Where(p => p.Guid == product).Any())
				throw new ArgumentException("Product not found");
			Product p = _applicationDbContext.Products.Remove(_applicationDbContext.Products.Where(p => p.Guid == product).First()).Entity;
			_applicationDbContext.SaveChanges();
			return p;
		}

        public Product GetProduct(Guid guid) {
			if(_applicationDbContext.Products.Where(p => p.Guid == guid).Any())
				return _applicationDbContext.Products.Where(p => p.Guid == guid).First();
			else
				throw new ArgumentException("No correct GUID found");
        }

        public IQueryable<Product> GetProducts(int count)
		{
			return _applicationDbContext.Products;
		}

		public object? GetService(Type serviceType)
		{
			throw new NotImplementedException();
		}

		public Product UpdateProduct(Guid guid, Product product)
		{
			if (!_applicationDbContext.Products.Where(p => p.Guid == guid).Any())
				throw new ArgumentException("Product not found");

			Product p = _applicationDbContext.Products.Where(p => p.Guid == guid).First();
			p.Name = product.Name;
			p.Description = product.Description;

            _applicationDbContext.SaveChanges();
			return p;
		}
	}
}
