using Application.Command.MediatR;
using Domain.Models.Products;
using MediatR;
namespace Application.Features.Orders.Query
{//BaseCommandRequest
    public class GetOrdersQuery : BaseCommandRequest, IRequest<IEnumerable<ProductDto>>
    {

    }
}
