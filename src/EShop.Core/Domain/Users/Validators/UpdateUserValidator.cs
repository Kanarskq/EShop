using EShop.Core.Domain.Users.Data;
using FluentValidation;

namespace EShop.Core.Domain.Users.Validators;

internal class UpdateUserValidator : AbstractValidator<UpdateUserData>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.UserName)
           .NotEmpty()
           .WithMessage("Username is required.")
           .Length(3, 50)
           .WithMessage("Username must be between 3 and 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty()
            .WithMessage("Password is required.")
            .Length(6, 100)
            .WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .Length(1, 50).WithMessage("First name must be between 1 and 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Length(1, 50).WithMessage("Last name must be between 1 and 50 characters.");
    }
}
