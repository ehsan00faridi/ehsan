using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.command.Event
{
    public class CreateOrderEvent:INotification
    {
        public DateTime Data { get; set; }
    }
}
