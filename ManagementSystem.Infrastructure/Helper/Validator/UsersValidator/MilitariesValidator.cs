using FluentValidation;
using ManagamentSystem.Core.Entities.UserInformatıons;

namespace ManagementSystem.Infrastructure.Helper.Validator.UsersValidator
{
	public class MilitariesValidator : AbstractValidator<MilitaryStatus>
	{
        public MilitariesValidator()
        {
            RuleFor(x => x.IsDone).NotNull().WithMessage("Please choose whether you do or do not ");
            
        }
    }
}
