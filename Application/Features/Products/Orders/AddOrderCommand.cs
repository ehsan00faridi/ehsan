using Application.Command.MediatR;
using MediatR;

namespace Application.Features.Products.Orders
{
    public class AddOrderCommand:BaseCommandRequest,IRequest<bool>
    {

        public int ProductId { get; set; }
        public int Qty { get; set; }

    }
}
