using FluentValidation;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Helper.Validator.BuysValidator
{
	public class SueDetailsValidator :AbstractValidator<SueDetails>

	{
        public SueDetailsValidator()
        {
            RuleFor(x => x.JobName).NotEmpty().NotNull().WithMessage("Please Enter Sue Detail's Name");
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Please Enter Product Id");

        }
    }
}
