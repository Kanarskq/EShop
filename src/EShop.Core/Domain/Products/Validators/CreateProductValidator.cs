using EShop.Core.Domain.Products.Data;
using FluentValidation;

namespace EShop.Core.Domain.Products.Validators;

internal class CreateProductValidator : AbstractValidator<CreateProductData>
{
    public CreateProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name is required.")
            .Length(1, 100)
            .WithMessage("Product name must be between 1 and 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Product description is required.")
            .Length(1, 1000)
            .WithMessage("Product description must be between 1 and 1000 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");

        RuleFor(x => x.Stock)
            .NotEmpty()
            .WithMessage("Stock is required.");

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category ID is required.");

        RuleFor(x => x.ImageData)
            .NotEmpty()
            .WithMessage("Product image data is required.");
    }
}
