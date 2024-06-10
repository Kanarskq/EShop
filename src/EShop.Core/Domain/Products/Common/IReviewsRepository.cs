using EShop.Core.Domain.Products.Models;

namespace EShop.Core.Domain.Products.Common;

public interface IReviewsRepository
{
    public Task<Review> FindAsync(Guid userId, Guid productId, CancellationToken cancellationToken);

    public void Add(Review review);

    public void Update(Review review);

    public void Delete(Review review);
}
