using At.Mausa.Grasmaster.Domain.Models.Domain;

namespace At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;
public interface IProductService : IServiceProvider
{
    public IQueryable<Product> GetProducts(int count);
    public Product CreateProduct(Product product);
    public Product UpdateProduct(Product product);
    public Product DeleteProdukt(Product product);
}


