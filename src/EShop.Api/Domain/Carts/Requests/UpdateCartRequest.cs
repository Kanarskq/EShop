using EShop.Core.Domain.Carts.Models;

namespace EShop.Api.Domain.Carts.Requests;

public record UpdateCartRequest(
    Guid UserId, 
    List<CartItem> Items);
