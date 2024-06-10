using FluentValidation;
using FluentValidation.Results;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Carts.Rules;

namespace EShop.Core.Domain.Carts.Validators;

internal class UpdateCartValidator : AbstractValidator<UpdateCartData>
{
    public UpdateCartValidator(IUserMustExistChecker userMustExistChecker)
    {
        RuleFor(x => x.UserId)
        .CustomAsync(async (productId, context, cancellationToken) =>
        {
            var ruleResult =
                    await new UserMustExistRule(productId, userMustExistChecker).CheckAsync(cancellationToken);
            if (ruleResult.IsSuccess) return;
            foreach (var error in ruleResult.Errors) context.AddFailure(new ValidationFailure(nameof(CartItem), error));
        });
    }
}
