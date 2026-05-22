using Application.Command.MediatR;
using MediatR;

namespace Application.Features.Products.Orders
{
    public class AddOrderCommand:BaseCommandRequest,IRequest<bool>
    {

        public string Email { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
    }
}
