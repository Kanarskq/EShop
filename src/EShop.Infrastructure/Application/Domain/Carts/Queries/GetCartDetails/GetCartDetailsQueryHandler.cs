using EShop.Application.Domain.Carts.Queries.GetCartDetails;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Application.Domain.Carts.Queries.GetCartDetails;

public class GetCartDetailsQueryHandler(EShopDbContext eShopDbContext)
    : IRequestHandler<GetCartDetailsQuery, CartDetailsDto>
{
    public async Task<CartDetailsDto> Handle(GetCartDetailsQuery request, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Carts
                .Include(c => c.Items)
                .Select(a => new CartDetailsDto
                {
                    UserId = a.UserId,
                    Items = a.Items.Select(item => new CartItemDto
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        Price = item.Price
                    }).ToList(),
                    CreatedAt = a.CreatedAt,
                    UpdatedAt = a.UpdatedAt
                })
                .FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken)
                ?? throw new NotFoundException($"{nameof(Cart)} with id: '{request.UserId}' was not found.");
    }
}
