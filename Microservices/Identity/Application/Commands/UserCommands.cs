using CryptoJackpot.Identity.Application.DTOs;
using MediatR;

namespace CryptoJackpot.Identity.Application.Commands;

public class UpdateUserCommand : IRequest<ResultResponse<UserDto?>>
{
    public long UserId { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Phone { get; set; }
    public string? Password { get; set; }
}

public class UpdatePasswordCommand : IRequest<ResultResponse<UserDto?>>
{
    public long UserId { get; set; }
    public string CurrentPassword { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
}

public class RequestPasswordResetCommand : IRequest<ResultResponse<string>>
{
    public string Email { get; set; } = null!;
}

public class ResetPasswordWithCodeCommand : IRequest<ResultResponse<UserDto?>>
{
    public string Email { get; set; } = null!;
    public string SecurityCode { get; set; } = null!;
    public string NewPassword { get; set; } = null!;
    public string ConfirmPassword { get; set; } = null!;
}

public class GenerateNewSecurityCodeCommand : IRequest<ResultResponse<UserDto?>>
{
    public long UserId { get; set; }
}

