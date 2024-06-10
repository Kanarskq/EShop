using EShop.Core.Domain.Products.Data;
using FluentValidation;

namespace EShop.Core.Domain.Products.Validators;

internal class UpdateCategoryValidator : AbstractValidator<UpdateCategoryData>
{
    public UpdateCategoryValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .Length(1, 100)
                .WithMessage("Category name must be between 1 and 100 characters.");

        RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Category description is required.")
                .Length(1, 500)
                .WithMessage("Category description must be between 1 and 500 characters.");

    }
}
