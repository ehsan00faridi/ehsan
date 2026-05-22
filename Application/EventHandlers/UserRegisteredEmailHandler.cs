using Application.Application_DTO;
using Application.Interfaces;
using Domain.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventHandlers
{
    public class UserRegisteredEmailHandler : INotificationHandler<UserRegisteredDomainEvent>
    {
        private readonly IEmailService _emailService;

        public UserRegisteredEmailHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task Handle(UserRegisteredDomainEvent notification, CancellationToken cancellationToken)
        {
            var message = new EmailMessage
            {//"ehsanfaridi1382@gmail.com"
                To = notification.Email,
                Subject = "Welcome 🎉",
                Body = "<h1>Welcome to our platform</h1>"
            };


            await _emailService.SendAsync(message, cancellationToken);
        }
    }

}
