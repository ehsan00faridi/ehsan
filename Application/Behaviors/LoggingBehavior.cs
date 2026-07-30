using MediatR;

namespace Application.Behaviors
{
    internal class LoggingBehavior<TReguest, TResponse> : IPipelineBehavior<TReguest, TResponse> where TReguest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TReguest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //pre
            Console.WriteLine("Handling" + typeof(TReguest).Name);


            var Response = await next();

            //post
            Console.WriteLine("Handled" + typeof(TReguest).Name);


            return Response;
        }
    }
}
