namespace EShop.Api.Domain.Products.Requests;

public record CreateReviewRequest(
    Guid UserId,
    Guid ProductId,
    string Comment,
    int Rating);
