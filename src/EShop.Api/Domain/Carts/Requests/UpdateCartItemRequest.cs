namespace EShop.Api.Domain.Carts.Requests;

public record UpdateCartItemRequest(
    Guid CartItemId,
    Guid ProductId,
    int Quantity,
    decimal Price);
