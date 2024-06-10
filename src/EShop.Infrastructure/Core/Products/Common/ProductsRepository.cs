using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Core.Products.Common;

public class ProductsRepository(EShopDbContext eShopDbContext) : IProductsRepository
{
    public void Add(Product product)
    {
        eShopDbContext.Products.Add(product);
    }

    public void Delete(IReadOnlyCollection<Product> products)
    {
        eShopDbContext.Products.RemoveRange(products);
    }

    public async Task<Product> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await eShopDbContext.Products.SingleOrDefaultAsync(c => c.ProductId == id);
        return product ?? throw new NotFoundException($"{nameof(Product)} with id: '{id}' was not found.");
    }

    public async Task<IReadOnlyCollection<Product>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Products
            .Where(a => ids.Contains(a.ProductId))
            .ToArrayAsync(cancellationToken);
    }

    public void Update(Product product)
    {
        eShopDbContext.Products.Update(product);
    }
}