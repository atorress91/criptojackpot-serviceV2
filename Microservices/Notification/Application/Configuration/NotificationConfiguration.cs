namespace CryptoJackpot.Notification.Application.Configuration;

public class NotificationConfiguration
{
    public BrevoSettings? Brevo { get; set; }
    public SmtpSettings? Smtp { get; set; }
}

public class BrevoSettings
{
    public string ApiKey { get; set; } = null!;
    public string SenderEmail { get; set; } = null!;
    public string SenderName { get; set; } = null!;
    public string BaseUrl { get; set; } = null!;
}

public class SmtpSettings
{
    public string Host { get; set; } = null!;
    public int Port { get; set; }
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
    public bool UseSsl { get; set; }
    public string SenderEmail { get; set; } = null!;
    public string SenderName { get; set; } = null!;
}
