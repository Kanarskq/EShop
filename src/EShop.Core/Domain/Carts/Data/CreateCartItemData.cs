namespace EShop.Core.Domain.Carts.Data;

public record CreateCartItemData(
    Guid ProductId,
    int Quantity,
    decimal Price)
{
}
