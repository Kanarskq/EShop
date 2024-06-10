using EShop.Core.Common;
using EShop.Persistence;
using EShop.Infrastructure.Processing;

namespace EShop.Infrastructure.Core.Common;

internal class UnitOfWork(
    EShopDbContext eShopDbContest,
    IEnumerationIgnorer enumerationIgnorer)
    : IUnitOfWork
{
    private readonly EShopDbContext eShopDbContest = eShopDbContest ?? throw new ArgumentNullException(nameof(eShopDbContest));

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        enumerationIgnorer.IgnoreEnumerations();
        return await eShopDbContest.SaveChangesAsync(cancellationToken);
    }
}
