using CryptoJackpot.Notification.Domain.Models;

namespace CryptoJackpot.Notification.Domain.Interfaces;

public interface IEmailTemplateRepository
{
    Task<EmailTemplate?> GetByNameAsync(string templateName);
    Task<IEnumerable<EmailTemplate>> GetAllActiveAsync();
}
