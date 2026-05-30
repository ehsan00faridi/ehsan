using Application.Command.Pagination;
using Application.Features.Products.Dto;
using Domain.Models.Products;
using MediatR;
namespace Application.Features.Products.Query
{



    public class GetProductsQueryHandler
      : IRequestHandler<GetProductsQuery, PaginatedList<ProductDto>>
    {
        private readonly IProductQueries _productQueries;

        public GetProductsQueryHandler(IProductQueries productQueries)
        {
            _productQueries = productQueries;
        }

        public async Task<PaginatedList<ProductDto>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productQueries.GetProductsAsync(
                request.Search,
                request.PageNumber,
                request.PageSize,
                request.DisablePaging);
        }
    }



}
/*
    public class GetProductsQueryHandler
      : IRequestHandler<GetProductsQuery, PaginatedList<ProductDto>>
    {
        private readonly IProductQueries _productQueries;

        public GetProductsQueryHandler(IProductQueries productQueries)
        {
            _productQueries = productQueries;
        }

        public async Task<PaginatedList<ProductDto>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            return await _productQueries.GetProductsAsync(
                request.Search,
                request.PageNumber,
                request.PageSize,
                request.DisablePaging);
        }
    }
 */

/*
   public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, PaginatedList<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<PaginatedList<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            


            return await _productRepository
                .Get(a => a.Enable)
                .SearchQuery(request.Search)
                .ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync( request.PageNumber,request.PageSize,request.DisablePaging);
         
        }
    }
 
 */