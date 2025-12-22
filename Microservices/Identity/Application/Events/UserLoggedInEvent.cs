using CryptoJackpot.Domain.Core.Events;

namespace CryptoJackpot.Identity.Application.Events;

/// <summary>
/// Event published via IEventBus when a user successfully logs in.
/// Other microservices can subscribe to this event.
/// </summary>
public class UserLoggedInEvent(long userId, string email, string userName) : Event
{
    public long UserId { get; } = userId;
    public string Email { get; } = email;
    public string UserName { get; } = userName;
    public DateTime LoginTime { get; } = DateTime.UtcNow;
}
