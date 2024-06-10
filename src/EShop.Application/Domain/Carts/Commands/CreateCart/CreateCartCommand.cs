using EShop.Core.Domain.Carts.Models;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.CreateCart;

public record CreateCartCommand(
    Guid UserId) : IRequest<Guid>;

