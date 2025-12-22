using CryptoJackpot.Domain.Core.Events;

namespace CryptoJackpot.Domain.Core.IntegrationEvents.Identity;

/// <summary>
/// Integration event published when a user successfully logs in.
/// Consumed by: Audit, Analytics microservices
/// </summary>
public class UserLoggedInEvent : Event
{
    public long UserId { get; set; }
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public DateTime LoginTime { get; set; } = DateTime.UtcNow;

    public UserLoggedInEvent() { }

    public UserLoggedInEvent(long userId, string email, string userName)
    {
        UserId = userId;
        Email = email;
        UserName = userName;
        LoginTime = DateTime.UtcNow;
    }
}

