using FluentValidation;

namespace Application.Features.Products.Command.Validation
{
    public class DeleteProductValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductValidator() { 
        RuleFor(i=>i.id).NotEmpty().WithMessage("مقدار خالی ") .NotNull().Must(p => p > 0)
                .WithMessage(" صفر یاکمتر از صفر نمیتواند باشد");
        }

    }
}
