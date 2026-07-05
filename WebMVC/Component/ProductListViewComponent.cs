using Application.Features.Products.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Component
{

    public class ProductListViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private const int DefaultPageNumber = 1;
        private const int DefaultPageSize = 12;
        private const int MaxPageSize = 50;

        public ProductListViewComponent(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IViewComponentResult> InvokeAsync(
            int pageNumber = DefaultPageNumber,
            int pageSize = DefaultPageSize,
            string? search = null,
            bool disablePaging = false)
        {
            pageNumber = pageNumber < 1 ? DefaultPageNumber : pageNumber;
            pageSize = pageSize < 1 ? DefaultPageSize : pageSize;
            pageSize = pageSize > MaxPageSize ? MaxPageSize : pageSize;

            var query = new GetProductsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Search = search?.Trim() ?? string.Empty,
                DisablePaging = disablePaging
            };

            var data = await _mediator.Send(query);
            
            return View("/Views/Shared/ViewComponents/ProductList.cshtml", data);
        }
    }

}

