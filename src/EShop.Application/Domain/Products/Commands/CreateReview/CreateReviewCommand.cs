using MediatR;

namespace EShop.Application.Domain.Products.Commands.CreateReview;

public record CreateReviewCommand(
    Guid UserId,
    Guid ProductId,
    string Comment,
    int Rating) : IRequest<Guid>;

