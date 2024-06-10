using EShop.Core.Common;
using EShop.Core.Domain.Carts.Common;
using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Domain.Common;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.CreateCart;

public class CreateCartCommandHandler(
    ICartsRepository cartRepository,
    IUserMustExistChecker userMustExistChecker,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateCartCommand, Guid>
{
    public async Task<Guid> Handle(CreateCartCommand request, CancellationToken cancellationToken)
    {
        var createCartData = new CreateCartData
        (
            request.UserId
        );

        var cart = Cart.Create(userMustExistChecker, createCartData);

        cartRepository.Add(cart);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return cart.UserId;
    }

}
