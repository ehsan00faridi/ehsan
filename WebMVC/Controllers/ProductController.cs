    using Application.Features.Products.Command;
    using Application.Features.Products.Dto;
    using Application.Features.Products.Query;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
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

            [Authorize(Roles ="Admin")]
            public async Task<IActionResult> Index()
            {
                ProductList date = new ProductList();
                var ProductList= await _mediator.Send(date);
                return View(ProductList);
            }


            [Authorize]
            [HttpGet("GetProduct/{Id}")]
            public async Task<IActionResult> GetProduct(int Id)
            {
                var Query = new GetProductByIdQuery() { Id=Id};
                var data = await _mediator.Send(Query);
                return View(data);

            }

            [HttpGet("GetProductList")]
            public async Task<IActionResult> ProductList([FromQuery] GetProductsQuery Query)
            {
         
                var data = await _mediator.Send(Query);
                ViewBag.search=Query.Search;
                return View(data);
            }

            [Authorize(Roles = "Admin")]
            [HttpGet("Product/Delete/{id}")] 
            public async Task<IActionResult> Delete(int id)
            {
                var query = new GetProductByIdQuery() { Id = id };
                var data = await _mediator.Send(query);

                if (data == null) return NotFound(); 

                return View(data);
            }
            [Authorize(Roles = "Admin")]
            [HttpPost("Product/Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete([FromForm] DeleteProductCommand command)
            {
                var result = await _mediator.Send(command);

            
                return RedirectToAction(nameof(Index));
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
            public async Task<IActionResult> AddProduct([FromForm] AddProductCommand command)
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
                return RedirectToAction(nameof(Index));
            }

            [Authorize(Roles = "Admin")]
            [HttpGet("UpdateProduct/{Id:int}")]
            public async Task<IActionResult> UpdateProduct( int Id)
            {
                var query = new GetProductByIdQuery() { Id = Id };
                var data = await _mediator.Send(query);
          
                return View(data);

            }

            [Authorize(Roles = "Admin")]
            [HttpPost("UpdateProduct")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> UpdateProduct(  UpdateProductCommand command)
            {
            if ( command== null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(command);
            }

            var data = await _mediator.Send(command);

            TempData["SuccessMessage"] = "تغییرات محصول با موفقیت ذخیره شد.";
            return RedirectToAction(nameof(Index));
        }
        }
    }
