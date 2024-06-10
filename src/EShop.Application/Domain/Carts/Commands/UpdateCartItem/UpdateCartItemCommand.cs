using MediatR;

namespace EShop.Application.Domain.Carts.Commands.UpdateCartItem;

public record UpdateCartItemCommand(
    Guid CartItemId,
    Guid ProductId,
    int Quantity,
    decimal Price)
    : IRequest;
