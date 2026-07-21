using Domain.Models.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Query
{
    public class ProductListHandler : IRequestHandler<ProductList, IEnumerable<ProductDto>>
    { 
        private readonly IProductRepository _productRepository;
        public ProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<IEnumerable<ProductDto>> Handle(ProductList request, CancellationToken cancellationToken)
        {
            var product = _productRepository.GetAllProducts();
            return product;
        }
    }
}
