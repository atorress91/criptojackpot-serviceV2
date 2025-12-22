using CryptoJackpot.Domain.Core.Responses;
using CryptoJackpot.Identity.Application.Commands;
using CryptoJackpot.Identity.Application.DTOs;
using CryptoJackpot.Identity.Application.Extensions;
using CryptoJackpot.Identity.Application.Interfaces;
using CryptoJackpot.Identity.Domain.Interfaces;
using MediatR;

namespace CryptoJackpot.Identity.Application.Handlers.Commands;

public class AuthenticateCommandHandler : IRequestHandler<AuthenticateCommand, ResultResponse<UserDto?>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IIdentityEventPublisher _eventPublisher;

    public AuthenticateCommandHandler(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService,
        IPasswordHasher passwordHasher,
        IIdentityEventPublisher eventPublisher)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _passwordHasher = passwordHasher;
        _eventPublisher = eventPublisher;
    }

    public async Task<ResultResponse<UserDto?>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);

        if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
            return ResultResponse<UserDto?>.Failure(ErrorType.Unauthorized, "Invalid Credentials");

        if (!user.Status)
            return ResultResponse<UserDto?>.Failure(ErrorType.Forbidden, "User Not Verified");

        var userDto = user.ToDto();
        userDto.Token = _jwtTokenService.GenerateToken(user.Id.ToString());

        await _eventPublisher.PublishUserLoggedInAsync(user);

        return ResultResponse<UserDto?>.Ok(userDto);
    }
}
