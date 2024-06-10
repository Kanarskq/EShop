namespace EShop.Api.Domain.Carts.Requests;

public record CreateCartItemRequest(
    Guid ProductId,
    int Quantity,
    decimal Price);
