using MediatR;

namespace EShop.Application.Domain.Carts.Queries.GetCartDetails;

public record GetCartDetailsQuery(Guid UserId) : IRequest<CartDetailsDto>;
