

using At.Mausa.Grasmaster.Domain.Models.Domain;
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

        public IQueryable<Product> GetProducts(int count)
        {
            return _applicationDbContext.Products;
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
