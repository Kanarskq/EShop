namespace EShop.Core.Domain.Common;

public interface IProductMustExistChecker
{
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}
