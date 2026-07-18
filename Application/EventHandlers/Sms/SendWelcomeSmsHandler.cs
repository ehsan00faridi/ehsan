using Application.Features.Orders.Event;
using Application.Services.Sms;
using MediatR;

namespace Application.EventHandlers.Smd
{
    public class SendWelcomeSmsHandler : INotificationHandler<UserRegisteredEvent>
    {
        private readonly ISmsService _smsService;

        public SendWelcomeSmsHandler(ISmsService smsService)
        {
            _smsService = smsService;
        }

        public    Task Handle(UserRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var message = $"Welcome {notification.UserName}";

             _smsService.SendAsync(notification.PhoneNumber, message);

           return  Task.CompletedTask;
           
        }
    }

}
