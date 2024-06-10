using MediatR;

namespace EShop.Application.Domain.Users.Commands.DeleteUser;

public record DeleteUsersCommand (IReadOnlyCollection<Guid> Ids) : IRequest;
