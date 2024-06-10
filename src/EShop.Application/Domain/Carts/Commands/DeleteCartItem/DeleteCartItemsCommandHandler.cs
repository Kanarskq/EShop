using EShop.Core.Common;
using EShop.Core.Domain.Carts.Common;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.DeleteCartItem;

public class DeleteCartItemsCommandHandler(
    ICartItemsRepository cartItemRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<DeleteCartItemsCommand>
{
    public async Task Handle(DeleteCartItemsCommand request, CancellationToken cancellationToken)
    {
        var authors = await cartItemRepository.FindManyAsync(request.Ids, cancellationToken);

        cartItemRepository.Delete(authors);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
