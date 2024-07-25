using FluentValidation;
using ManagamentSystem.Core.Entities;

namespace ManagementSystem.Infrastructure.Helper.Validator.UsersValidator
{
	public class AppUserValidator : AbstractValidator<AppUser>
	{
        public AppUserValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().NotNull().WithMessage("Please Enter a User's Name");
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().WithMessage("Please Enter a Valid User's Email Address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Please Enter a Password")
                                    .Length(8, 12).WithMessage("Your password must be between 8 and 16 characters");
            RuleFor(x => x.Gender).NotNull().WithMessage("Please select your gender");
        }
    }
}
