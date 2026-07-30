using Domain.Models.Ordera;
using Domain.Models.Products;
using MediatR;
namespace Application.Features.Orders.Query
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<ProductDto>>
    {
        private readonly   IOrdersRepository _ordersRepository;
        public GetOrdersQueryHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<IEnumerable<ProductDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            
         var data = await _ordersRepository.
                GetOrders(
             request.UserId
             );
            return (data);
        }
    }
}
