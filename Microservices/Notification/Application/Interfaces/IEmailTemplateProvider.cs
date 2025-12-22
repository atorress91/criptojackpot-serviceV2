namespace CryptoJackpot.Notification.Application.Interfaces;

public interface IEmailTemplateProvider
{
    Task<string?> GetTemplateAsync(string templateName);
}
