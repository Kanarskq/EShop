using EShop.Application.Domain.Products.Commands.DeleteProduct;
using EShop.Core.Common;
using EShop.Core.Domain.Products.Common;
using MediatR;

namespace EShop.Application.Domain.Products.Commands.DeleteReview;

public class DeleteReviewCommandHandler(
    IReviewsRepository reviewRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteReviewCommand>
{
    public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await reviewRepository.FindAsync(request.UserId, request.ProductId, cancellationToken);

        reviewRepository.Delete(review);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
