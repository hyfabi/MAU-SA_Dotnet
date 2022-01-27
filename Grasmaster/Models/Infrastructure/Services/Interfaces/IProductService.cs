using Grasmaster.Infrastructure.Models;

namespace Grasmaster.Infrastructure.Services.Interfaces
{
    public interface IProductService : IServiceProvider
    {
        public IReadOnlyList<Product> GetProducts();
        public Product CreateProduct(Product product);
        public Product UpdateProduct(Product product);
        public Product DeleteProdukt(Product product);
    }
}
