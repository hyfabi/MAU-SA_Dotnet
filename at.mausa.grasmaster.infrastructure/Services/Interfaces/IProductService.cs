using At.Mausa.Grasmaster.Domain.Models;

namespace At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;
public interface IProductService : IServiceProvider
{
    public IQueryable<Product> GetProducts(int count);
    public Product GetProduct(Guid guid);
    public Product CreateProduct(Product product);
    public Product UpdateProduct(Guid guid, Product product);
    public Product DeleteProduct(Guid guid);
}


