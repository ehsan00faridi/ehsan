using Application.Command.Exceptions;
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

            _logger.LogError(exception, "Unhandled exception occurred");

            if (exception is CustomException custom)
            {
                context.Result = new BadRequestObjectResult(new
                {
                    message = custom.Message,  
                    errors = custom.Errors    
                });

                context.ExceptionHandled = true;
                return;
            }

         
            context.Result = new ObjectResult(new
            {
                message = "Server error",
                detail = _env.IsDevelopment() ? exception.ToString() : null
            })
            { StatusCode = StatusCodes.Status500InternalServerError };

            context.ExceptionHandled = true;
        }
    }
}
