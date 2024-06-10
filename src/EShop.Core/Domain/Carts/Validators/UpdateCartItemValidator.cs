using EShop.Core.Domain.Carts.Data;
using EShop.Core.Domain.Carts.Models;
using EShop.Core.Domain.Carts.Rules;
using EShop.Core.Domain.Common;
using FluentValidation;
using FluentValidation.Results;

namespace EShop.Core.Domain.Carts.Validators;

internal class UpdateCartItemValidator : AbstractValidator<UpdateCartItemData>
{
    public UpdateCartItemValidator(IProductMustExistChecker productMustExistChecker)
    {
        RuleFor(x => x.ProductId)
            .CustomAsync(async (productId, context, cancellationToken) =>
            {
                var ruleResult =
                    await new ProductMustExistRule(productId, productMustExistChecker).CheckAsync(cancellationToken);
                if (ruleResult.IsSuccess) return;
                foreach (var error in ruleResult.Errors) context.AddFailure(new ValidationFailure(nameof(CartItem), error));
            });
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}
