using FluentValidation;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.Validator.WaresValidator
{
	public class CategiriesValidator : AbstractValidator<Category>
	{
        public CategiriesValidator()
        {
            RuleFor(x=> x.Name).NotNull().NotEmpty().WithMessage("Please Enter a Category's Name");
            
        }
    }
}
