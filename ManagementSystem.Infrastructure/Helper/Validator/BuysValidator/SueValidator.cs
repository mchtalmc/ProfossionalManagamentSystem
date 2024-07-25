using FluentValidation;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Helper.Validator.BuysValidator
{
	public class SueValidator : AbstractValidator<Sue>
	{
        public SueValidator()
        {
            RuleFor(x => x.SueTypeNumber).NotEmpty().WithMessage("Please Select the Sue Type");
            RuleFor(x => x.SurStatus).NotNull().WithMessage("Please Select the Sue Status");
        }
    }
}
