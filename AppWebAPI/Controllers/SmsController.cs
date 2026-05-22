using Microsoft.AspNetCore.Mvc;

using Application.Services.Sms;

namespace AppWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SmsController : ControllerBase
    {
        private readonly ISmsService _sms;

        public SmsController(ISmsService sms)
        {
            _sms = sms;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send(string phone, string message)
        {
            await _sms.SendAsync(phone, message);
            return Ok("SMS Sent");
        }

        [HttpPost("otp")]
        public async Task<IActionResult> SendOtp(string phone)
        {
            var code = new Random().Next(1000, 9999).ToString();
            await _sms.SendOtpAsync(phone, code);
            return Ok($"OTP Sent: {code}");
        }
    }
}
