using CryptoJackpot.Notification.Data.Context;
using CryptoJackpot.Notification.Domain.Interfaces;
using CryptoJackpot.Notification.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoJackpot.Notification.Data.Repositories;

public class EmailTemplateRepository : IEmailTemplateRepository
{
    private readonly NotificationDbContext _context;

    public EmailTemplateRepository(NotificationDbContext context)
    {
        _context = context;
    }

    public async Task<EmailTemplate?> GetByNameAsync(string templateName)
    {
        return await _context.EmailTemplates
            .FirstOrDefaultAsync(t => t.Name == templateName && t.IsActive);
    }

    public async Task<IEnumerable<EmailTemplate>> GetAllActiveAsync()
    {
        return await _context.EmailTemplates
            .Where(t => t.IsActive)
            .ToListAsync();
    }
}
