using EShop.Application.Domain.Carts.Queries.GetCartDetails;
using MediatR;

namespace EShop.Application.Domain.Carts.Queries.GetCartItemDetails;

public record GetCartItemDetailsQuery(Guid CartItemId) : IRequest<CartItemDetailsDto>;

