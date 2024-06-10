using EShop.Core.Common;
using EShop.Core.Domain.Carts.Common;
using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Common;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.UpdateCartItem;

public class UpdateCartItemCommandHandler(
    ICartItemsRepository cartItemRepository,
    IProductMustExistChecker productMustExistChecker,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateCartItemCommand>
{
    public async Task Handle(UpdateCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await cartItemRepository.FindAsync(request.CartItemId, cancellationToken);

        var updateCartItemData = new UpdateCartItemData(
            request.ProductId,
            request.Quantity, 
            request.Price);

        cartItem.Update(productMustExistChecker, updateCartItemData);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
