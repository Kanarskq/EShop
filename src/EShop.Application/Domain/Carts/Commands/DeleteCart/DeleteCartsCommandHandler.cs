using EShop.Core.Common;
using EShop.Core.Domain.Carts.Common;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.DeleteCart;

public class DeleteCartsCommandHandler(
    ICartsRepository cartRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteCartsCommand>
{
    public async Task Handle(DeleteCartsCommand request, CancellationToken cancellationToken)
    {
        var carts = await cartRepository.FindManyAsync(request.Ids, cancellationToken);

        cartRepository.Delete(carts);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
