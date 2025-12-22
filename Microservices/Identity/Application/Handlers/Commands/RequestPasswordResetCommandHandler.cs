using CryptoJackpot.Domain.Core.Responses;
using CryptoJackpot.Identity.Application.Commands;
using CryptoJackpot.Identity.Application.Interfaces;
using CryptoJackpot.Identity.Domain.Interfaces;
using MediatR;

namespace CryptoJackpot.Identity.Application.Handlers.Commands;

public class RequestPasswordResetCommandHandler : IRequestHandler<RequestPasswordResetCommand, ResultResponse<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IIdentityEventPublisher _eventPublisher;

    public RequestPasswordResetCommandHandler(
        IUserRepository userRepository,
        IIdentityEventPublisher eventPublisher)
    {
        _userRepository = userRepository;
        _eventPublisher = eventPublisher;
    }

    public async Task<ResultResponse<string>> Handle(RequestPasswordResetCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if (user is null)
            return ResultResponse<string>.Failure(ErrorType.NotFound, "User not found");

        var securityCode = new Random().Next(100000, 999999).ToString();
        user.SecurityCode = securityCode;
        user.PasswordResetCodeExpiration = DateTime.UtcNow.AddMinutes(15);

        await _userRepository.UpdateAsync(user);
        await _eventPublisher.PublishPasswordResetRequestedAsync(user, securityCode);

        return ResultResponse<string>.Ok("Password reset email sent");
    }
}
