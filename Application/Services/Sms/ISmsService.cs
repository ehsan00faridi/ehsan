namespace Application.Services.Sms
{
    public interface ISmsService
    {
        Task SendAsync(string phoneNumber, string message);
        Task SendOtpAsync(string phoneNumber, string code);
    }
}
