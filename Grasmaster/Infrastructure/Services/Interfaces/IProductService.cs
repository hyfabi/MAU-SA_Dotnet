using Grasmaster.Infrastructure.Models;

namespace Grasmaster.Infrastructure.Services.Interfaces
{
public interface IProductService : IServiceProvider
{
		Task<IEnumerable<Product>> GetAllAsync();
		Task<Product> GetSingleOrDefaultAsync(long id);
		Task<Product> CreateAsync(Product newModel);
		Task<Product> EditAsync(Guid id, Product newModel);
		Task DeleteAsync(Guid? id);
	}
}
