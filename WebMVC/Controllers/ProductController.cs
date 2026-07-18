using Application.Features.Products.Command;
using Application.Features.Products.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> GetProduct(int Id)////valifation nadarad
        {
            var Query = new GetProductByIdQuery() { Id=Id};
            var data = await _mediator.Send(Query);
            return View(data);

        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsQuery Query)
        {
         
            var data = await _mediator.Send(Query);
            return Ok(data);
        }

            [HttpPost("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] DeleteProductCommand command)
        {

          //  var Query = new GetProductByIdQuery() { Id = Id };
            var data = await _mediator.Send(command);
            return Ok(data);

        }
        [Authorize(Roles = "Admin")]
        [HttpGet("AddProduct")]
        public IActionResult AddProduct()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("AddProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(
            [FromForm] AddProductCommand command)
        {
            if (!ModelState.IsValid)
                return View(command);

            var result = await _mediator.Send(command);

            if (!result)
            {
                ModelState.AddModelError(string.Empty, "ثبت محصول با خطا مواجه شد.");
                return View(command);
            }

            TempData["SuccessMessage"] = "محصول با موفقیت ثبت شد.";
            return RedirectToAction(nameof(AddProduct));
        }


        //[HttpPost("AddProduct")]
        //public async Task<IActionResult> AddProduct([FromBody]AddProductCommand command) { 
        //var data= await _mediator.Send(command); 
        //    return Ok(data);

        //}


        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
          var data=   await _mediator.Send(command);
            
            return Ok(data);

        }
    }
}
