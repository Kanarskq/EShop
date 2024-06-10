using EShop.Core.Domain.Users.Common;
using EShop.Core.Domain.Users.Models;
using EShop.Core.Exceptions;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Core.Users.Common;

public class UsersRepository(EShopDbContext eShopDbContext) : IUserRepository
{
    public void Add(User user)
    {
        eShopDbContext.Users.Add(user);
    }

    public void Delete(IReadOnlyCollection<User> users)
    {
        eShopDbContext.Users.RemoveRange(users);
    }

    public async Task<User> FindAsync(Guid id, CancellationToken cancellationToken)
    {
        var user = await eShopDbContext.Users.SingleOrDefaultAsync(c => c.UserId == id);
        return user ?? throw new NotFoundException($"{nameof(User)} with id: '{id}' was not found.");
    }

    public async Task<User> FindByEmailAsync(string email, CancellationToken cancellationToken)
    {
        var user = await eShopDbContext.Users.SingleOrDefaultAsync(c => c.Email == email);
        return user ?? throw new NotFoundException($"{nameof(User)} with email: '{email}' was not found.");
    }

    public async Task<User> FindByUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        var user = await eShopDbContext.Users.SingleOrDefaultAsync(c => c.UserName == userName);
        return user ?? throw new NotFoundException($"{nameof(User)} with UserName: '{userName}' was not found.");
    }

    public async Task<IReadOnlyCollection<User>> FindManyAsync(IReadOnlyCollection<Guid> ids, CancellationToken cancellationToken)
    {
        return await eShopDbContext.Users
            .Where(a => ids.Contains(a.UserId))
            .ToArrayAsync(cancellationToken);
    }

    public void Update(User user)
    {
        eShopDbContext.Users.Update(user);
    }
}