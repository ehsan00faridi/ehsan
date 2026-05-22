using Domain.Models.Products;
using MediatR;

namespace Application.Features.Products.Query
{
    public  class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRpository;

        public GetProductByIdQueryHandler(IProductRepository productRpository)
        {
            _productRpository = productRpository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRpository.FindAsync(request.Id);
            return product;
        }
    }
}
