using Application.Features.Orders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebMVC.Models;
namespace WebMVC.Controllers
{
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Order/AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] AddBasketDto model)
        {
            if (model == null)
            {
                return BadRequest(new { res = false, msg = "اطلاعات ارسالی معتبر نیست." });
            }

            try
            {
                // ۱. ساخت کامند با استفاده از مقادیر DTO
                var command = new AddOrderCommand()
                {
                    ProductId = model.ProductId,
                    Qty = model.qty
                };

                // ۲. ارسال کامند به مدیتور و await کردن آن
                var result = await _mediator.Send(command);

                // ۳. خروجی موفقیت‌آمیز کاملاً JSON
                return Ok(new { res = true });
            }
            catch (Exception ex)
            {
                // در صورت بروز هرگونه خطای داخلی، ساختار JSON معتبر برگردانده شود تا فرانت کرش نکند
                return StatusCode(500, new { res = false, msg = ex.Message });
            }
        }

    }
}
