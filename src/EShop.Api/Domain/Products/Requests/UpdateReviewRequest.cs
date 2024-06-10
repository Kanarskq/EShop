namespace EShop.Api.Domain.Products.Requests;

public record UpdateReviewRequest(
    Guid UserId,
    Guid ProductId,
    string Comment,
    int Rating);
