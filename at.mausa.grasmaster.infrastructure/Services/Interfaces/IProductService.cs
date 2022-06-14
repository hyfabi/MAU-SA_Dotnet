using At.Mausa.Grasmaster.Domain.Models;

using System.Linq.Expressions;

namespace At.Mausa.Grasmaster.Infrastructure.Services.Interfaces;
public interface IProductService : IServiceProvider
{
    public List<Product> GetProducts(Expression<Func<Product, bool>>? filter = null,
        Func<IQueryable<Product>, IOrderedQueryable<Product>>? sortOrder = null,
        Func<IQueryable<Product>, PagenatedList<Product>>? paging = null);
    public Product GetProduct(Guid guid);
    public Product CreateProduct(Product product);
    public Product UpdateProduct(Guid guid, Product product);
    public Product DeleteProduct(Guid guid);
}


