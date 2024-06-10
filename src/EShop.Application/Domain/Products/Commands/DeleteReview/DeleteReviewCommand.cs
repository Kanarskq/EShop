using MediatR;

namespace EShop.Application.Domain.Products.Commands.DeleteReview;

public record DeleteReviewCommand(Guid UserId, Guid ProductId ) : IRequest;
