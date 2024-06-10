using EShop.Core.Common;
using EShop.Core.Domain.Carts.Common;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Products.Common;
using EShop.Core.Domain.Users.Common;
using EShop.Infrastructure.Core.Carts.Common;
using EShop.Infrastructure.Core.Common;
using EShop.Infrastructure.Core.Products.Common;
using EShop.Infrastructure.Core.Users.Common;
using EShop.Infrastructure.Processing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EShop.Infrastructure;

public static class InfrastructureRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // mediatr
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // checkers
        services.AddScoped<IUserMustExistChecker, UserMustExistChecker>();
        services.AddScoped<IProductMustExistChecker, ProductMustExistChecker>();

        // repositories
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UsersRepository>();
        services.AddScoped<IReviewsRepository, ReviewsRepository>();
        services.AddScoped<IProductsRepository, ProductsRepository>();
        services.AddScoped<ICategoriesRepository, CategoriesRepository>();
        services.AddScoped<ICartsRepository, CartsRepository>();
        services.AddScoped<ICartItemsRepository, CartItemsRepository>();

        // processing
        services.AddScoped<IEnumerationIgnorer, EnumerationIgnorer>();
    }
}
