using EShop.Application.Domain.Users.Queries.GetUserDetails;
using EShop.Core.Domain.Users.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Application.Domain.Users.Queries.GetUserDetails;

public class GetUserDetailsQueryHandler(EShopDbContext eShopDbContext)
    : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
{
    public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Users
                .Where(u => u.UserId == request.UserId)
                .Select(u => new UserDetailsDto
                {
                    UserId = u.UserId,
                    UserName = u.UserName,
                    Email = u.Email,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    CreatedAt = u.CreatedAt
                })
                .FirstOrDefaultAsync(cancellationToken)
                ?? throw new NotFoundException($"{nameof(User)} with id: '{request.UserId}' was not found.");
    }
}

