using FluentValidation;

namespace Application.Features.Products.Command.Validation
{
    public class AddProductValidator:AbstractValidator<AddProductCommand>
    {
        public AddProductValidator() { 
        
        RuleFor(i=>i.Name).NotEmpty().WithMessage("نام نباید خالی باشد")
                .NotNull().WithMessage("نام نباید خالی باشد").MaximumLength(50).WithMessage("نام نباید بیش از 50 کاراکتر باشد");
            RuleFor(s => s.Price).Must(p => p > 0).WithMessage("قیمت صفر نمیتواند باشد");
            RuleFor(q => q.Qty ).Must(x=>x !=0).WithMessage("تعداد نبابد صفر باشد");
        }





    }
}
