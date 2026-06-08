using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace AppWebAPI.Filters
{

    public class CustomActionFilter : IActionFilter
    {
        private Stopwatch _stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();

            Console.WriteLine();
            Console.WriteLine($"Action( {context.ActionDescriptor.DisplayName})is starting...");
            Console.WriteLine();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var elapsedMilliseconds = _stopwatch.ElapsedMilliseconds;

            Console.WriteLine();
            Console.WriteLine($"Action {context.ActionDescriptor.DisplayName} executed in ({elapsedMilliseconds}) ms");
            Console.WriteLine();
        }
    }

}
