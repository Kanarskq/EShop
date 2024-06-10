namespace EShop.Core.Domain.Products.Data;

public record UpdateReviewData(
    Guid ProductId,
    Guid UserId,
    string Comment,
    int Rating)
{
}
