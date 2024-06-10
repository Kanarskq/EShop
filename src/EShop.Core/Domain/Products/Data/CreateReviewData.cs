namespace EShop.Core.Domain.Products.Data;

public record CreateReviewData(
    Guid UserId,
    Guid ProductId,
    string Comment,
    int Rating)
{
}
