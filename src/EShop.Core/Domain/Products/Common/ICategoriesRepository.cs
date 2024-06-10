using EShop.Core.Domain.Products.Models;

namespace EShop.Core.Domain.Products.Common;

public interface ICategoriesRepository
{
    public Task<Category> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Category>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public void Add(Category category);

    public void Update(Category category);

    public void Delete(IReadOnlyCollection<Category> categories);
}
