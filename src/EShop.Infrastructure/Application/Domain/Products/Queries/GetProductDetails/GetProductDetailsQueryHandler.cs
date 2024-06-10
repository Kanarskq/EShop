using EShop.Application.Domain.Products.Queries.GetProductDetails;
using EShop.Core.Domain.Products.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Application.Domain.Products.Queries.GetProductDetails;

public class GetProductDetailsQueryHandler(EShopDbContext eShopDbContext)
    : IRequestHandler<GetProductDetailsQuery, ProductDto>
{
    public async Task<ProductDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Products
                .Include(p => p.Category)
                .Include(p => p.Reviews)
                .Where(p => p.ProductId == request.ProductId)
                .Select(p => new ProductDto
                {
                    ProductId = p.ProductId,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryId = p.CategoryId,
                    CategoryName = p.Category.Name,
                    ImageData = p.ImageData,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    Reviews = p.Reviews.Select(r => new ReviewDto
                    {
                        UserId = r.UserId,
                        Comment = r.Comment,
                        Rating = r.Rating,
                        CreatedAt = r.CreatedAt
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundException($"{nameof(Product)} with id: '{request.ProductId}' was not found.");

    }
}