using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Core.Products.Common;

public class CategoriesRepository(EShopDbContext eShopDbContext) : ICategoriesRepository
{
    public void Add(Category cart)
    {
        eShopDbContext.Categories.Add(cart);
    }

    public void Delete(IReadOnlyCollection<Category> categories)
    {
        eShopDbContext.Categories.RemoveRange(categories);
    }

    public async Task<Category> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var category = await eShopDbContext.Categories.SingleOrDefaultAsync(c => c.CategoryId == id);
        return category ?? throw new NotFoundException($"{nameof(Category)} with id: '{id}' was not found.");
    }

    public async Task<IReadOnlyCollection<Category>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Categories
            .Where(a => ids.Contains(a.CategoryId))
            .ToArrayAsync(cancellationToken);
    }

    public void Update(Category category)
    {
        eShopDbContext.Categories.Update(category);
    }
}
