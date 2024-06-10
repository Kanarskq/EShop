using EShop.Core.Domain.Common;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Core.Common;

public class UserMustExistChecker(EShopDbContext eShopDbContext) : IUserMustExistChecker
{
    public async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await eShopDbContext.Users.AnyAsync(a => a.UserId == id, cancellationToken);
    }
}
