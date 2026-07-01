using Application.Features.Products.Dto;
using Application.Interfaces;
using Domain.Models.Products;
using MediatR;

namespace Application.Features.Products.Query
{
    public  class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Domain.Models.Products.ProductDto>
    {
        private readonly IProductRepository _GetproductById;

        public GetProductByIdQueryHandler(IProductRepository productById)
        {
            _GetproductById = productById;
        }

        public async Task<Domain.Models.Products.ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _GetproductById.GetProductById(request.Id);
            return product;
        }
    }
}
