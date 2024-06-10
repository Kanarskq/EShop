using EShop.Core.Domain.Carts.Models;

namespace EShop.Core.Domain.Carts.Common;

public interface ICartItemsRepository
{
    public Task<CartItem> FindAsync(Guid id, CancellationToken cancellationToken);

    public Task<IReadOnlyCollection<CartItem>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken);

    public void Add(CartItem cartItem);

    public void Delete(IReadOnlyCollection<CartItem> cartItems);

    public void Update(CartItem cartItem);

}
