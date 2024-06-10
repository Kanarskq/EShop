using EShop.Core.Common;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Data;
using EShop.Core.Domain.Products.Models;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.CreateReview;

public class CreateReviewCommandHandler(
    IReviewsRepository reviewRepository,
    IProductMustExistChecker productMustExistChecker,
    IUserMustExistChecker userMustExistChecker,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateReviewCommand, Guid>
{
    public async Task<Guid> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var createReviewData = new CreateReviewData
        (
            request.UserId,
            request.ProductId,
            request.Comment,
            request.Rating
        );

        var review = Review.Create(productMustExistChecker, userMustExistChecker, createReviewData);

        reviewRepository.Add(review);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return review.UserId;
    }

}
