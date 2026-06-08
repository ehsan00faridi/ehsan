
using Application.Application_DTO;
using Application.Interfaces;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Infrastrucure.Email
{
    public class SmtpEmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public SmtpEmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value;
        }

        public async Task SendAsync(EmailMessage message, CancellationToken cancellationToken = default)
        {
            //Console.WriteLine(message.To
            //    + "   jj                                                jj                                               jj                                    jj" + _settings.Username);
            using var client = new SmtpClient(_settings.Host, _settings.Port)
            {
                Credentials = new NetworkCredential(
                    _settings.Username,
                    _settings.Password),


                EnableSsl = true
            };

            var mail = new MailMessage(
                _settings.From,
                message.To,
                message.Subject,
                message.Body)
            {
                IsBodyHtml = message.IsHtml
            };

            await client.SendMailAsync(mail, cancellationToken);
        }
    }

}
