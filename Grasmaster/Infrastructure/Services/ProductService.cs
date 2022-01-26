using Grasmaster.Infrastructure.Context;
using Grasmaster.Infrastructure.Models;
using Grasmaster.Infrastructure.Services.Interfaces;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Grasmaster.Infrastructure.Services
{
	public class ProductService : IProductService
	{
		private ApplicationContext _applicationContext;

		public ProductService(ApplicationContext applicationContext) => _applicationContext = applicationContext;

		public Task<EntityEntry<Product>> CreateAsync1(Product product)
		{
			return _applicationContext.AddAsync(product).AsTask();
		}

		#region From IProductService-Interface
		public async Task<Product> CreateAsync(Product newModel)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(Guid? id)
		{
			throw new NotImplementedException();
		}

		public Task<Product> EditAsync(Guid id, Product newModel)
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<Product>> GetAllAsync()
		{
			throw new NotImplementedException();
		}

		public Task<Product> GetSingleOrDefaultAsync(long id)
		{
			throw new NotImplementedException();
		}

        public object? GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
