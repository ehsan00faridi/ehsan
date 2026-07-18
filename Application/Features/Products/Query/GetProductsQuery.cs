using Application.Command.MediatR;
using Application.Command.Pagination;

using MediatR;

namespace Application.Features.Products.Query
{
    public class GetProductsQuery : BaseQueryRequest,  IRequest<PaginatedList<Domain.Models.Products.ProductDto>>
    {
    }
}
