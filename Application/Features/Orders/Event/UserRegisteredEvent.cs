using MediatR;

namespace Application.Features.Orders.Event
{
    public class UserRegisteredEvent :INotification
    {
        public string PhoneNumber { get; set; }=string.Empty;

        public string UserName { get; set; } = string.Empty;
    }

}
