using CryptoJackpot.Notification.Data.Context;
using CryptoJackpot.Notification.Domain.Interfaces;
using CryptoJackpot.Notification.Domain.Models;

namespace CryptoJackpot.Notification.Data.Repositories;

public class NotificationLogRepository : INotificationLogRepository
{
    private readonly NotificationDbContext _context;

    public NotificationLogRepository(NotificationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(NotificationLog log)
    {
        await _context.NotificationLogs.AddAsync(log);
        await _context.SaveChangesAsync();
    }
}
