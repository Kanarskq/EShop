using EShop.Core.Common;
using EShop.Core.Domain.Carts.Common;
using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Common;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.UpdateCart;

public class UpdateCartCommandHandler(
    ICartsRepository cartRepository,
    IUserMustExistChecker userMustExistChecker,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateCartCommand>
{
    public async Task Handle(UpdateCartCommand request, CancellationToken cancellationToken)
    {
        var cart = await cartRepository.FindAsync(request.UserId, cancellationToken);

        var updateCartData = new UpdateCartData(request.UserId,request.Items);

        cart.Update(userMustExistChecker, updateCartData);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
