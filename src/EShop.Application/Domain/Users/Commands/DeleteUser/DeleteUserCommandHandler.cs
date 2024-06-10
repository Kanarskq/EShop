using EShop.Application.Domain.Users.Commands.DeleteUser;
using EShop.Core.Common;
using EShop.Core.Domain.Users.Common;
using MediatR;

namespace EShop.Application.Domain.Carts.Commands.DeleteCart;

internal class DeleteUsersCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteUsersCommand>
{
    public async Task Handle(DeleteUsersCommand request, CancellationToken cancellationToken)
    {
        var users = await userRepository.FindManyAsync(request.Ids, cancellationToken);

        userRepository.Delete(users);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
