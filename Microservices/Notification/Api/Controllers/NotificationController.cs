using CryptoJackpot.Notification.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoJackpot.Notification.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("email-confirmation")]
    public async Task<IActionResult> SendEmailConfirmation([FromBody] SendEmailConfirmationRequest request)
    {
        var result = await _notificationService.SendEmailConfirmationAsync(
            request.UserId, request.Email, request.Name, request.LastName, request.Token);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("password-reset")]
    public async Task<IActionResult> SendPasswordReset([FromBody] SendPasswordResetRequest request)
    {
        var result = await _notificationService.SendPasswordResetEmailAsync(
            request.Email, request.Name, request.LastName, request.SecurityCode);
        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("referral-notification")]
    public async Task<IActionResult> SendReferralNotification([FromBody] SendReferralNotificationRequest request)
    {
        var result = await _notificationService.SendReferralNotificationAsync(
            request.ReferrerEmail, request.ReferrerName, request.ReferrerLastName,
            request.ReferredName, request.ReferredLastName, request.ReferralCode);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}

public class SendEmailConfirmationRequest
{
    public long UserId { get; set; }
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Token { get; set; } = null!;
}

public class SendPasswordResetRequest
{
    public string Email { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string SecurityCode { get; set; } = null!;
}

public class SendReferralNotificationRequest
{
    public string ReferrerEmail { get; set; } = null!;
    public string ReferrerName { get; set; } = null!;
    public string ReferrerLastName { get; set; } = null!;
    public string ReferredName { get; set; } = null!;
    public string ReferredLastName { get; set; } = null!;
    public string ReferralCode { get; set; } = null!;
}
