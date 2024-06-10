using EShop.Core.Common;
using EShop.Core.Domain.Users.Common;
using EShop.Core.Domain.Users.Data;
using MediatR;

namespace EShop.Application.Domain.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork
    ) : IRequestHandler<UpdateUserCommand>
{
    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.FindAsync(request.UserId, cancellationToken);

        var updateUserData = new UpdateUserData(
            request.UserName, 
            request.Email,
            request.PasswordHash,
            request.FirstName,
            request.LastName
            );

        user.Update(updateUserData);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
