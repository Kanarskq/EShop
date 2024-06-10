using EShop.Core.Domain.Carts.Models;

namespace EShop.Core.Domain.Carts.Common;

public interface ICartsRepository
{
    public Task<Cart> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<Cart>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public void Add(Cart cart);

    public void Delete(IReadOnlyCollection<Cart> carts);

    public void Update(Cart cart);
}
