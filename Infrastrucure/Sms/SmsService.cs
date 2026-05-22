using Application.Services.Sms;
using Kavenegar;
using Microsoft.Extensions.Configuration;

namespace Infrastrucure.Services.Sms
{
    public class SmsService : ISmsService
    {
        private readonly IConfiguration _config;
        private readonly KavenegarApi _api;
        private readonly string _sender;

        public SmsService(IConfiguration config)
        {
            _config = config;

            var apiKey = _config["Sms:ApiKey"];
            _sender = _config["Sms:Sender"];

            _api = new KavenegarApi(apiKey);
        }

        public async Task SendAsync(string phoneNumber, string message)
        {
            await Task.Run(() =>
            {
                _api.Send(_sender, phoneNumber, message);
            });
        }

        public async Task SendOtpAsync(string phoneNumber, string code)
        {
            string message = $"کد تایید شما: {code}";
            await SendAsync(phoneNumber, message);
        }
    }
}
