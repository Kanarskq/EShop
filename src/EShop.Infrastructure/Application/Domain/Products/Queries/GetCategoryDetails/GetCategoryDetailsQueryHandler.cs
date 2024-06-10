using EShop.Application.Domain.Products.Queries.GetCategoryDetails;
using EShop.Core.Domain.Products.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Application.Domain.Products.Queries.GetCategoryDetails;

public class GetCategoryDetailsQueryHandler(EShopDbContext eShopDbContext)
    : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
{
    public async Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Categories
                .Include(c => c.Products)
                .Where(c => c.CategoryId == request.CategoryId)
                .Select(c => new CategoryDetailsDto
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description,
                    Products = c.Products.Select(p => new ProductDto
                    {
                        ProductId = p.ProductId,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Stock = p.Stock,
                        ImageData = p.ImageData
                    }).ToList()
                })
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundException($"{nameof(Category)} with id: '{request.CategoryId}' was not found.");
    }
}