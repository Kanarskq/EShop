using EShop.Core.Common;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Products.Models;

namespace EShop.Core.Domain.Products.Rules;

internal class ProductMustExistRule(
    Guid productId,
    IProductMustExistChecker productMustExistChecker)
    : IBusinessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var exists = await productMustExistChecker.ExistsAsync(productId, cancellationToken);
        return Check(exists);
    }

    private RuleResult Check(bool exists)
    {
        if (exists) return RuleResult.Success();
        return RuleResult.Failed($"{nameof(Product)} was not found. {nameof(Product.ProductId)}: '{productId}'.");
    }
}
