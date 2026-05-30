using FluentValidation;

namespace Application.Features.Products.Orders.Validation
{
    public class AddOrderValidation : AbstractValidator<AddOrderCommand>
    {
        public AddOrderValidation() {
            RuleFor(i => i.Email).EmailAddress().WithMessage("فرمت Emailدرست نیست "); 
         


        }
    }
}
