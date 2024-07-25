using FluentValidation;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.Validator.WaresValidator
{
	public class MarketPlaceValidator : AbstractValidator<MarketPlace>
	{
        public MarketPlaceValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().NotNull().WithMessage("Please Enter Market Place Name");
            RuleFor(x => x.Location).NotNull().NotEmpty().WithMessage("Please ENter Market Place's Location");
            
        }
    }
}
