using EShop.Application.Domain.Carts.Queries.GetCartItemDetails;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Application.Domain.Carts.Queries.GetCartItemDetails;

public class GetCartItemDetailsQueryHandler(EShopDbContext eShopDbContext)
    : IRequestHandler<GetCartItemDetailsQuery, CartItemDetailsDto>
{
    public async Task<CartItemDetailsDto> Handle(GetCartItemDetailsQuery request, CancellationToken cancellationToken)
    {
        return await eShopDbContext.CartItems
                .Where(ci => ci.CartItemId == request.CartItemId)
                .Select(ci => new CartItemDetailsDto
                {
                    CartItemId = ci.CartItemId,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                    Price = ci.Price
                })
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundException($"{nameof(CartItem)} with id: '{request.CartItemId}' was not found.");
    }
}

