using CryptoJackpot.Identity.Application.DTOs;
using MediatR;

namespace CryptoJackpot.Identity.Application.Queries;

public class GetUserByIdQuery : IRequest<ResultResponse<UserDto?>>
{
    public long UserId { get; set; }
}

public class GetAllUsersQuery : IRequest<ResultResponse<IEnumerable<UserDto>>>
{
    public long? ExcludeUserId { get; set; }
}

