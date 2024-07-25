using FluentValidation;
using ManagamentSystem.Core.Entities.Buy;

namespace ManagementSystem.Infrastructure.Helper.Validator.BuysValidator
{
	public class ContractorValidator : AbstractValidator<Contractor>
	{
        public ContractorValidator()
        {
            RuleFor(x=> x.Address).NotEmpty().NotNull().WithMessage("Please Enter Contractor's Location");
            RuleFor(x=> x.PhoneNumber).NotEmpty().WithMessage("Please Enter Contractor's Phone Number")
                                        .Length(11).WithMessage("Please Enter a Valid Phone Number")
										.Matches(@"^\d+$").WithMessage("The phone number must consist of numbers only");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Please Enter a Valid Email Address");

           
		}
    }
}
