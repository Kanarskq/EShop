using EShop.Core.Domain.Carts.Models;

namespace EShop.Core.Domain.Carts.Data;

public record UpdateCartData(
    Guid UserId,
    List<CartItem> Items)
{
}
