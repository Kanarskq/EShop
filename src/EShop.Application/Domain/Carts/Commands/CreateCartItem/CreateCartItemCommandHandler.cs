using EShop.Core.Common;
using EShop.Core.Domain.Carts.Common;
using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Domain.Common;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.CreateCartItem;

public class CreateCartItemCommandHandler(
    ICartItemsRepository cartItemRepository,
    IProductMustExistChecker productMustExistChecker,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCartItemCommand, Guid>
{
    public async Task<Guid> Handle(CreateCartItemCommand request, CancellationToken cancellationToken)
    {
        var createCartItemData = new CreateCartItemData
        (
            request.ProductId,
            request.Quantity,
            request.Price
        );

        var cartItem = CartItem.Create(productMustExistChecker, createCartItemData);

        cartItemRepository.Add(cartItem);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return cartItem.CartItemId;
    }
}
