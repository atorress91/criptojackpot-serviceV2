namespace CryptoJackpot.Notification.Application.Interfaces;

public interface IEmailProvider
{
    Task<bool> SendEmailAsync(string to, string subject, string body);
}
