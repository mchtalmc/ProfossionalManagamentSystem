using FluentValidation;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.Validator.WaresValidator
{
	public class DealersValidator : AbstractValidator<Dealer>
	{
        public DealersValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().NotNull().WithMessage("Please Enter Dealer's Name");
            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().WithMessage("Please Enter a Valid Dealer's Email Address");
            RuleFor(x => x.Location).NotEmpty().NotNull().WithMessage("Please Enter Dealer's Location");
            
        }
    }
}
