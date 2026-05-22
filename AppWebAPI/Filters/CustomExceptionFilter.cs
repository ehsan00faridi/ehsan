using Application.Command.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AppWebAPI.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        private readonly IHostEnvironment _env;
        private readonly ILogger<CustomExceptionFilter> _logger;

        public CustomExceptionFilter(IHostEnvironment env, ILogger<CustomExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            //  Log Error
            //_logger.LogError
              Console.WriteLine  ($"{exception}, Unhandled exception occurred");
            if (context.Exception is CustomException custom)
            {
                context.Result = new ObjectResult(
                new
                {
                    Error = "",
                    Details=custom.Message,


                }
                )
                { StatusCode=500}
                    ;  

            }

            context.ExceptionHandled = true;


        
        }
    }

}
