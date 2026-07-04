using Application.Features.Products.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator) {
        _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddToBasket([FromBody] AddBasketDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Ok(new { res = false, msg = "شما لاگین نکرده اید" });
            }


            AddOrderCommand command = new AddOrderCommand() {ProductId=model.ProductId,Qty=model.qty};
            command.UserId =Convert.ToInt32( userId);
            _mediator.Send(model);
            //var result = await _orderService.AddToBasket(model.qty, model.bookId,
            //    Convert.ToInt32(userId));
            return Ok(new { res = true });
        }
    }
}
