using CryptoJackpot.Domain.Core.Events;

namespace CryptoJackpot.Notification.Application.Events;

public class PasswordResetRequestedEvent : Event
{
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string SecurityCode { get; set; } = null!;
}
