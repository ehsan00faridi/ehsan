using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Orders.Event
{
    public class DecreseAvailibilityEvent : INotificationHandler<CreateOrderEvent>
    {
        public Task Handle(CreateOrderEvent notification, CancellationToken cancellationToken)
        {
            // send email
//            Console.WriteLine("                      sendemail");

            return Task.CompletedTask;
        }
    }
}
