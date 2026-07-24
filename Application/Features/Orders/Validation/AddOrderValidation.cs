using Application.Features.Orders;
using FluentValidation;

namespace Application.Features.Orders.Validation
{
    public class AddOrderValidation : AbstractValidator<AddOrderCommand>
    {
        public AddOrderValidation() {
           
            RuleFor(i=>i.Qty).NotEmpty().Must(cont=>cont>0).WithMessage("مقدار خالی نباید باشد یا کمتر از صفر نباید باشد");
            RuleFor(p => p.ProductId).NotNull().Must(cont => cont > 0).WithMessage("مقدار خالی نباید باشد یا کمتر از صفر نباید باشد");
        }
    }
}
