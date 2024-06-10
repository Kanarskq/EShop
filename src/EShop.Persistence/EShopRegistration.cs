using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Persistence;

public static class EShopRegistration
{
    private const string ConnectionStringName = "EShop";

    public static void AddEShopPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(ConnectionStringName)
                               ?? throw new AggregateException($"Connection string: '{ConnectionStringName}' is not found in configurations.");

        services.AddDbContext<EShopDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsHistoryTable(
                        EShopDbContext.EShopDbMigrationsHistoryTable,
                        EShopDbContext.EShopDbSchema);
                });
        });
    }
}
