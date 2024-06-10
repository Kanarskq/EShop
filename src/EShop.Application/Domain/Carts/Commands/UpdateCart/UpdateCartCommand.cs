using EShop.Core.Domain.Carts.Models;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.UpdateCart;

public record UpdateCartCommand(
    Guid UserId, 
    List<CartItem> Items) 
    : IRequest;
