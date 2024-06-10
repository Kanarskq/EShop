using MediatR;

namespace EShop.Application.Domain.Users.Queries.GetUserDetails;

public record GetUserDetailsQuery(Guid UserId) : IRequest<UserDetailsDto>;

