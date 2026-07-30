using Application.Features.Orders.command;
using Application.Features.Orders.Query;
using Application.Features.Products.Command;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class OrderController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IBackgroundJobClient _backgroundjobClient;
        private readonly IRecurringJobManager _jobmanger;
        public OrderController(IMediator mediator, IBackgroundJobClient jobClient, IRecurringJobManager jobmanger)
        {
            _mediator = mediator;
            this._backgroundjobClient = jobClient;
            this._jobmanger = jobmanger;
        }

       


        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderCommand command)
        {
            var data = await _mediator.Send(command);
            return Ok(data);

        }

        [HttpPost("Test")]
        public async Task<IActionResult> Test()
        {
            _backgroundjobClient.Schedule(() => Console.WriteLine("Fire____and_____forget     job executed"), TimeSpan.FromSeconds(5));

            return Ok(true);

        }


    }
}
