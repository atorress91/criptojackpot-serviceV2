using CryptoJackpot.Domain.Core.Responses;
using CryptoJackpot.Identity.Application.Commands;
using CryptoJackpot.Identity.Domain.Interfaces;
using MediatR;

namespace CryptoJackpot.Identity.Application.Handlers.Commands;

public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, ResultResponse<string>>
{
    private readonly IUserRepository _userRepository;

    public ConfirmEmailCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultResponse<string>> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Token))
            return ResultResponse<string>.Failure(ErrorType.BadRequest, "Invalid confirmation token");

        var user = await _userRepository.GetBySecurityCodeAsync(request.Token);

        if (user == null)
            return ResultResponse<string>.Failure(ErrorType.NotFound, "Invalid confirmation token");

        if (user.Status)
            return ResultResponse<string>.Failure(ErrorType.BadRequest, "Email already confirmed");

        user.Status = true;
        user.SecurityCode = null;
        await _userRepository.UpdateAsync(user);

        return ResultResponse<string>.Ok("Email confirmed successfully");
    }
}
