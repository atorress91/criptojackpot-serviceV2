namespace CryptoJackpot.Notification.Application.DTOs;

public class SendEmailConfirmationRequest
{
    public long UserId { get; set; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Token { get; set; } = null!;
}
