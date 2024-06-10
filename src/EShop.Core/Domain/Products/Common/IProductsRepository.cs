using EShop.Core.Domain.Products.Models;

namespace EShop.Core.Domain.Products.Common;

public interface IProductsRepository
{
    public Task<Product> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Product>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public void Add(Product product);

    public void Update(Product product);

    public void Delete(IReadOnlyCollection<Product> products);
}
