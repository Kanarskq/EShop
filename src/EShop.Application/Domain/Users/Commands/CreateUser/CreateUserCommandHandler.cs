using EShop.Core.Common;
using EShop.Core.Domain.Users.Common;
using EShop.Core.Domain.Users.Data;
using EShop.Core.Domain.Users.Models;
using MediatR;

namespace EShop.Application.Domain.Users.Commands.CreateUser;

public class CreateUserCommandHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var createUserData = new CreateUserData
        (
            request.UserName,
            request.Email,
            request.PasswordHash,
            request.FirstName,
            request.LastName
        );

        var user = User.Create(createUserData);

        userRepository.Add(user);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return user.UserId;
    }

}
