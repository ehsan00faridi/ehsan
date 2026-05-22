using Application.Command.Exception;
using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly  IEnumerable< IValidator<TRequest>> _validator;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures=_validator
                .Select(i=>i.Validate(context))
                .SelectMany(i=>i.Errors)
                .Where(i=> i !=null)
                .Select(error=>error.ErrorMessage)
                .ToList();

            if (failures.Any()) {
                throw new CustomException(String.Join(" , ",failures) );
            }

            return await next();
                
        }
    }
}
