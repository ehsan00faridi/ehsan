using Application.Command.MediatR;
using Application.Command.Pagination;
using Application.Features.Products.Dto;

using MediatR;

namespace Application.Features.Products.Query
{
    public class GetProductsQuery : BaseQueryRequest,  IRequest<PaginatedList<ProductDto>>
    {
    }
}
