using MediatR;

namespace EShop.Application.Domain.Carts.Commands.CreateCartItem;

public record CreateCartItemCommand(
    Guid ProductId, 
    int Quantity, 
    decimal Price) : IRequest<Guid>;

