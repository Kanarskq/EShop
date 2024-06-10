using EShop.Application.Domain.Products.Queries.GetCategory;
using EShop.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace EShop.Infrastructure.Application.Domain.Products.Queries.GetCategories;

public class GetCategoriesQueryHandler(EShopDbContext eShopDbContext)
    : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
{
    public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Categories
                .Select(c => new CategoryDto
                {
                    CategoryId = c.CategoryId,
                    Name = c.Name,
                    Description = c.Description
                })
                .ToListAsync(cancellationToken);
    }
}
