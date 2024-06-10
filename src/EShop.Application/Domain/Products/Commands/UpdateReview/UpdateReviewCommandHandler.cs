using EShop.Application.Domain.Carts.Commands.UpdateCart;
using EShop.Core.Common;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Products.Data;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.UpdateReview;

public class UpdateReviewCommandHandler(
    IReviewsRepository reviewRepository,
    IProductMustExistChecker productMustExistChecker,
    IUserMustExistChecker userMustExistChecker,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateReviewCommand>
{
    public async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await reviewRepository.FindAsync(request.UserId, request.ProductId, cancellationToken);

        var updateReviewData = new UpdateReviewData(
            request.ProductId,
            request.UserId,
            request.Comment, 
            request.Rating);

        review.Update(productMustExistChecker, userMustExistChecker, updateReviewData);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
