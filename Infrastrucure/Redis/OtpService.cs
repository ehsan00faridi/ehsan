using Application.Interfaces;
using Application.Services.Sms;
using StackExchange.Redis;
using System.Security.Cryptography;
namespace Infrastructure.Redis
{


    public class OtpService : IOtpService
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly ISmsService _sms;

        private const int ExpireSeconds = 120;

        public OtpService(IConnectionMultiplexer redis, ISmsService sms)
        {
            _redis = redis;
            _sms = sms;
        }

        public async Task SendOtpAsync(string phoneNumber)
        {
            var db = _redis.GetDatabase();

            var otp = GenerateOtp();

            var key = $"otp:{phoneNumber}";

            await db.StringSetAsync(
                key,
                otp,
                TimeSpan.FromSeconds(ExpireSeconds)
            );

            await _sms.SendAsync(phoneNumber, $"کد تایید شما: {otp}");
            //Console.WriteLine("\n\n");
            //Console.WriteLine($" Code OTP : {otp} ");
            //Console.WriteLine("\n\n");
        }

        public async Task<bool> VerifyOtpAsync(string phoneNumber, string code)
        {
            var db = _redis.GetDatabase();

            var key = $"otp:{phoneNumber}";

            var storedCode = await db.StringGetAsync(key);

            if (storedCode.IsNullOrEmpty)
                return false;

            if (storedCode != code)
                return false;

            await db.KeyDeleteAsync(key);

            return true;
        }

        private string GenerateOtp()
        {
            var bytes = RandomNumberGenerator.GetBytes(4);
            var number = BitConverter.ToUInt32(bytes, 0) % 900000 + 100000;
            return number.ToString();
        }
    }

}
