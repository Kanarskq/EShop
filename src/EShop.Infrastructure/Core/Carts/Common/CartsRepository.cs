using EShop.Core.Domain.Carts.Common;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Core.Carts.Common;

public class CartsRepository(EShopDbContext eShopDbContext) : ICartsRepository
{
    public void Add(Cart cart)
    {
        eShopDbContext.Carts.Add(cart);
    }

    public void Delete(IReadOnlyCollection<Cart> carts)
    {
        eShopDbContext.Carts.RemoveRange(carts);
    }

    public async Task<Cart> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var cart = await eShopDbContext.Carts.SingleOrDefaultAsync(c => c.UserId == id);
        return cart ?? throw new NotFoundException($"{nameof(Cart)} with id: '{id}' was not found.");
    }

    public async Task<IReadOnlyCollection<Cart>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Carts
            .Where(a => ids.Contains(a.UserId))
            .ToArrayAsync(cancellationToken);
    }

    public void Update(Cart cart)
    {
        eShopDbContext.Carts.Update(cart);
    }
}
