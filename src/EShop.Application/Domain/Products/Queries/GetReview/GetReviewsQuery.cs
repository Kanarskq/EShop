using MediatR;

namespace EShop.Application.Domain.Products.Queries.GetReview;

public record GetReviewsQuery(Guid ProductId) : IRequest<List<ReviewDto>>;
