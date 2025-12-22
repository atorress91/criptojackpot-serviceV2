using CryptoJackpot.Domain.Core.Responses;
using CryptoJackpot.Identity.Application.Commands;
using CryptoJackpot.Identity.Application.DTOs;
using CryptoJackpot.Identity.Application.Extensions;
using CryptoJackpot.Identity.Application.Interfaces;
using CryptoJackpot.Identity.Domain.Interfaces;
using CryptoJackpot.Identity.Domain.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CryptoJackpot.Identity.Application.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ResultResponse<UserDto?>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IReferralService _referralService;
    private readonly IIdentityEventPublisher _eventPublisher;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateUserCommandHandler> _logger;

    private const long DefaultRoleId = 2;

    public CreateUserCommandHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IReferralService referralService,
        IIdentityEventPublisher eventPublisher,
        IUnitOfWork unitOfWork,
        ILogger<CreateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _referralService = referralService;
        _eventPublisher = eventPublisher;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<ResultResponse<UserDto?>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await _userRepository.ExistsByEmailAsync(request.Email))
            return ResultResponse<UserDto?>.Failure(ErrorType.BadRequest, "Email already registered");

        var referrer = await _referralService.ValidateReferralCodeAsync(request.ReferralCode);
        if (!string.IsNullOrEmpty(request.ReferralCode) && referrer is null)
            return ResultResponse<UserDto?>.Failure(ErrorType.BadRequest, "Invalid referral code");

        try
        {
            // Begin transaction - Outbox messages will be saved in the same transaction
            await _unitOfWork.BeginTransactionAsync(cancellationToken);

            var user = CreateUser(request);
            var createdUser = await _userRepository.CreateAsync(user);

            if (referrer != null)
                await _referralService.CreateReferralAsync(referrer, createdUser, request.ReferralCode!);

            // Publish event - with Outbox, this is saved to OutboxMessage table
            await _eventPublisher.PublishUserRegisteredAsync(createdUser);

            // Commit transaction - both user and outbox message are committed atomically
            await _unitOfWork.CommitTransactionAsync(cancellationToken);

            _logger.LogInformation("User {UserId} created successfully with outbox event", createdUser.Id);
            return ResultResponse<UserDto?>.Created(createdUser.ToDto());
        }
        catch (Exception ex)
        {
            await _unitOfWork.RollbackTransactionAsync(cancellationToken);
            _logger.LogError(ex, "Failed to create user for email {Email}", request.Email);
            return ResultResponse<UserDto?>.Failure(ErrorType.InternalServerError, "Failed to create user");
        }
    }

    private User CreateUser(CreateUserCommand request) => new()
    {
        Email = request.Email,
        Password = _passwordHasher.Hash(request.Password),
        Name = request.Name,
        LastName = request.LastName,
        Phone = request.Phone,
        CountryId = request.CountryId ?? 1,
        StatePlace = string.Empty,
        City = string.Empty,
        SecurityCode = Guid.NewGuid().ToString(),
        Status = false,
        RoleId = DefaultRoleId
    };
}