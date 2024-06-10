namespace EShop.Core.Domain.Common;

public interface IUserMustExistChecker
{
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
