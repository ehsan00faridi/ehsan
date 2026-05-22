using MediatR;

namespace Application.Behaviors
{
    public class ExptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
       public  async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
