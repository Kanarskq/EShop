using EShop.Core.Domain.Carts.Common;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Core.Carts.Common;

public class CartItemsRepository(EShopDbContext eShopDbContext) : ICartItemsRepository
{
    public void Add(CartItem cartItem)
    {
        eShopDbContext.CartItems.Add(cartItem);
    }

    public void Delete(IReadOnlyCollection<CartItem> cartItems)
    {
        eShopDbContext.CartItems.RemoveRange(cartItems);
    }

    public async Task<CartItem> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var cartItem = await eShopDbContext.CartItems.SingleOrDefaultAsync(c => c.CartItemId == id);
        return cartItem ?? throw new NotFoundException($"{nameof(CartItem)} with id: '{id}' was not found.");
    }

    public async Task<IReadOnlyCollection<CartItem>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await eShopDbContext.CartItems.Where(a => ids.Contains(a.CartItemId)).ToArrayAsync(cancellationToken);
    }

    public void Update(CartItem cartItem)
    {
        eShopDbContext.CartItems.Update(cartItem);
    }
}

