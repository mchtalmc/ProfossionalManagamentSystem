using FluentValidation;
using ManagamentSystem.Core.Entities.Wares;

namespace ManagementSystem.Infrastructure.Helper.Validator.WaresValidator
{
	public class ProductsValidator : AbstractValidator<Product>
	{
        public ProductsValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Please Enter Product Name");
            RuleFor(x => x.Price).NotEmpty().NotEqual(0).WithMessage("Enter a price greater than 0");
            RuleFor(x => x.Brand).NotEmpty().NotNull().WithMessage("Please Enter Product Brand");
          
        }
    }
}
