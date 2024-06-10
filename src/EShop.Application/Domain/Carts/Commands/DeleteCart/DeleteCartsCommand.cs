using MediatR;

namespace EShop.Application.Domain.Carts.Commands.DeleteCart;

public record DeleteCartsCommand(IReadOnlyCollection<Guid> Ids) : IRequest;
