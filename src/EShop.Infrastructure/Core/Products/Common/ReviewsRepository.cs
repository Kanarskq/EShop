using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Models;
using EShop.Core.Domain.Users.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Core.Products.Common;

public class ReviewsRepository(EShopDbContext eShopDbContext) : IReviewsRepository
{
    public void Add(Review review)
    {
        eShopDbContext.Reviews.Add(review);
    }

    public void Delete(Review review)
    {
        eShopDbContext.Reviews.RemoveRange(review);
    }

    public async Task<Review> FindAsync(Guid userId, Guid productId, CancellationToken cancellationToken)
    {
        var review = await eShopDbContext.Reviews
            .SingleOrDefaultAsync(r => r.UserId == userId && r.ProductId == productId, cancellationToken);
        return review ?? throw new NotFoundException($"{nameof(Review)} with UserId: '{userId}' and ProductId: '{productId}' was not found.");
    }

    public void Update(Review review)
    {
        eShopDbContext.Reviews.Update(review);
    }
}