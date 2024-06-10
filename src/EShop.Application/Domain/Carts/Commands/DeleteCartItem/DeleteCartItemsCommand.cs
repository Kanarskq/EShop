using MediatR;

namespace EShop.Application.Domain.Carts.Commands.DeleteCartItem;

public record DeleteCartItemsCommand(IReadOnlyCollection<Guid> Ids) : IRequest;
