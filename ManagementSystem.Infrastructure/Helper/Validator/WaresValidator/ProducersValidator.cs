using FluentValidation;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.Validator.WaresValidator
{
	public class ProducersValidator : AbstractValidator<Producer>
	{
        public ProducersValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please Enter Producer's Name");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Plaese Enter a valid Producer's Email Address");
            RuleFor(x => x.Location).NotNull().NotEmpty().WithMessage("Please Enter a Producer's Location");
        }
    }
}
