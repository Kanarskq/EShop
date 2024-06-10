using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Domain.Carts.Rules;
using EShop.Core.Domain.Common;
using FluentValidation;
using FluentValidation.Results;

namespace EShop.Core.Domain.Carts.Validators;

internal class CreateCartValidator : AbstractValidator<CreateCartData>
{
    public CreateCartValidator(IUserMustExistChecker userMustExistChecker)
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
