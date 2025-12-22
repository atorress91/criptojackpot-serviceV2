using CryptoJackpot.Notification.Domain.Models;

namespace CryptoJackpot.Notification.Domain.Interfaces;

public interface INotificationLogRepository
{
    Task AddAsync(NotificationLog log);
}
