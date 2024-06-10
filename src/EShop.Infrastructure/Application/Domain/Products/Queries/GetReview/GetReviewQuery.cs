using EShop.Application.Domain.Products.Queries.GetReview;
using EShop.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Application.Domain.Products.Queries.GetReview;

public class GetReviewQueryHandler(EShopDbContext eShopDbContext)
    : IRequestHandler<GetReviewsQuery, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Reviews
                .Where(r => r.ProductId == request.ProductId)
                .Select(r => new ReviewDto
                {
                    UserId = r.UserId,
                    ProductId = r.ProductId,
                    Comment = r.Comment,
                    Rating = r.Rating,
                    CreatedAt = r.CreatedAt,
                    UpdatedAt = r.UpdatedAt
                })
                .ToListAsync(cancellationToken);
    }
}
