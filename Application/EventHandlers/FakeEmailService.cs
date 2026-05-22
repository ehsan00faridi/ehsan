using Application.Application_DTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.EventHandlers
{
    public class FakeEmailService : IEmailService
    {
        public List<EmailMessage> SentEmails = new();

        public Task SendAsync(EmailMessage message, CancellationToken cancellationToken)
        {
            SentEmails.Add(message);
            return Task.CompletedTask;
        }
    }

}
