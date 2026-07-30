using Application.Features.Orders.command;
using Application.Features.Orders.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            GetOrdersQuery query = new GetOrdersQuery();
            var data = await _mediator.Send(query);

            return View(data);
        }
        [HttpPost]
        [Route("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] AddBasketDto model)
        {
            if (model == null)
            {
                return BadRequest(new { res = false, msg = "اطلاعات ارسالی معتبر نیست." });
            }

            try
            {
                
                var command = new AddOrderCommand()
                {
                    ProductId = model.ProductId,
                    Qty = model.qty
                };

              
                var result = await _mediator.Send(command);

              
                return Ok(new { res = true });
            }
            catch (Exception ex)
            {
              
                return StatusCode(500, new { res = false, msg = ex.Message });
            }
        }

    }
}
