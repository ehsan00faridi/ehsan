using Application.Command.MediatR;
using Application.Command.Pagination;
using Application.Features.Products.Dto;
using Domain.Models.Products;
using MediatR;

namespace Application.Features.Products.Query
{
    public class GetProductsQuery : BaseQueryRequest,  IRequest<PaginatedList<ProductDto>>
    {
    }
}
