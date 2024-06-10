using EShop.Core.Common;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Users.Models;

namespace EShop.Core.Domain.Products.Rules;

internal class UserMustExistRule(
    Guid userId,
    IUserMustExistChecker userMustExistChecker)
    : IBusinessRuleAsync
{
    public async Task<RuleResult> CheckAsync(CancellationToken cancellationToken = default)
    {
        var exists = await userMustExistChecker.ExistsAsync(userId, cancellationToken);
        return Check(exists);
    }

    private RuleResult Check(bool exists)
    {
        if (exists) return RuleResult.Success();
        return RuleResult.Failed($"{nameof(User)} was not found. {nameof(User.UserId)}: '{userId}'.");
    }
}
