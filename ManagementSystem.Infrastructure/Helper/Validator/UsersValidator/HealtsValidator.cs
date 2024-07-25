using FluentValidation;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Helper.Validator.UsersValidator
{
	public class HealtsValidator : AbstractValidator<HealthStatus>
	{
        public HealtsValidator()
        {
            RuleFor(x => x.HaveADisase).NotNull().WithMessage("Please Choose whether u do or do not");
            RuleFor(x => x.CanUseVehicle).NotNull().WithMessage("Please Choose whether u do or do not");
            RuleFor(x => x.DisabilityStatus).NotNull().WithMessage("Please Choose whether u do or do not");
        }
    }
}
