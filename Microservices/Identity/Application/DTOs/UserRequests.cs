using System.ComponentModel.DataAnnotations;

namespace CryptoJackpot.Identity.Application.DTOs;

public class UpdateUserRequest
{
    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Password { get; set; }
}

public class UpdatePasswordRequest
{
    [Required]
    public long UserId { get; set; }

    [Required]
    public string CurrentPassword { get; set; } = null!;

    [Required]
    [MinLength(6)]
    public string NewPassword { get; set; } = null!;
}

public class RequestPasswordResetRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}

public class ResetPasswordWithCodeRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string SecurityCode { get; set; } = null!;

    [Required]
    [MinLength(6)]
    public string NewPassword { get; set; } = null!;

    [Required]
    [Compare(nameof(NewPassword))]
    public string ConfirmPassword { get; set; } = null!;
}

