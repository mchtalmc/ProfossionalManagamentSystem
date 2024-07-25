using FluentValidation;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Helper.Validator.UsersValidator
{
	public class EducationValidator : AbstractValidator<EducationStatus>
	{
        public EducationValidator()
        {
            RuleFor(x=> x.Department).NotNull().NotEmpty().WithMessage("Please Enter a Education's Deparmants");
        }
    }
}
