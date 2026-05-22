using Application.Application_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default);
    }

}
