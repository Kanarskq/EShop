namespace EShop.Core.Domain.Carts.Data;

public record UpdateCartItemData(
    Guid ProductId,
    int Quantity,
    decimal Price)
{
}
