using Application.Features.Products.Dto;
using Application.Interfaces;
using Domain.Models.Products;
using MediatR;

namespace Application.Features.Products.Query
{
    public  class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductById _GetproductById;

        public GetProductByIdQueryHandler(IProductById productById)
        {
            _GetproductById = productById;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _GetproductById.FindAsync(request.Id);
            return product;
        }
    }
}
