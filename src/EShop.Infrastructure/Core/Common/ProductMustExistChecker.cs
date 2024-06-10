using EShop.Core.Domain.Common;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Core.Common;

public class ProductMustExistChecker(EShopDbContext eShopDbContext) : IProductMustExistChecker
{
    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await eShopDbContext.Products.AnyAsync(a => a.ProductId == id, cancellationToken);
    }
}