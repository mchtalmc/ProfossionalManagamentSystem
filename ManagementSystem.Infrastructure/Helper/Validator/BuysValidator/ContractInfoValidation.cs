using FluentValidation;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Helper.Validator.BuysValidator
{
	public class ContractInfoValidation : AbstractValidator<ContractInfo>
	{
        public ContractInfoValidation()
        {
            RuleFor(x => x.ContractName).NotNull().NotEmpty().WithMessage("Please Contract Name");
            RuleFor(x => x.ContractAmount).NotEmpty().NotEqual(0).WithMessage("Please Enter a Valid Contract's Amount");
        }
    }
}
