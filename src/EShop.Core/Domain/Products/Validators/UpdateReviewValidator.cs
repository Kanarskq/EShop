using EShop.Core.Domain.Products.Rules;
using EShop.Core.Domain.Common;
using EShop.Core.Domain.Products.Data;
using EShop.Core.Domain.Products.Models;
using FluentValidation;
using FluentValidation.Results;
using EShop.Core.Domain.Users.Models;

namespace EShop.Core.Domain.Products.Validators;

internal class UpdateReviewValidator : AbstractValidator<UpdateReviewData>
{
    public UpdateReviewValidator(
        IProductMustExistChecker productMustExistChecker,
        IUserMustExistChecker userMustExistChecker)
    {
        RuleFor(x => x.Comment)
            .NotEmpty().WithMessage("Comment is required.");

        RuleFor(x => x.Rating)
            .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");

        RuleFor(x => x.ProductId)
            .CustomAsync(async (productId, context, cancellationToken) =>
            {
                var ruleResult =
                    await new ProductMustExistRule(productId, productMustExistChecker).CheckAsync(cancellationToken);
                if (ruleResult.IsSuccess) return;
                foreach (var error in ruleResult.Errors) context.AddFailure(new ValidationFailure(nameof(Product), error));
            });

        RuleFor(x => x.UserId)
            .CustomAsync(async (userId, context, cancellationToken) =>
            {
                var ruleResult =
                    await new UserMustExistRule(userId, userMustExistChecker).CheckAsync(cancellationToken);
                if (ruleResult.IsSuccess) return;
                foreach (var error in ruleResult.Errors) context.AddFailure(new ValidationFailure(nameof(User), error));
            });
    }
}
