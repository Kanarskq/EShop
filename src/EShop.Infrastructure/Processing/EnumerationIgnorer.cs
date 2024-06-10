using EShop.Core.Common;
using EShop.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EShop.Infrastructure.Processing;

internal class EnumerationIgnorer(EShopDbContext eShopDbContext) : IEnumerationIgnorer
{
    public void IgnoreEnumerations()
    {
        var enumerationEntries = eShopDbContext
            .ChangeTracker
            .Entries()
            .Where(e => e.Entity is IEnumeration && e.State != EntityState.Unchanged);

        foreach (var enumerationEntry in enumerationEntries)
        {
            enumerationEntry.State = EntityState.Unchanged;
        }
    }
}
