using CryptoJackpot.Domain.Core.Responses;
using CryptoJackpot.Identity.Application.DTOs;
using MediatR;

namespace CryptoJackpot.Identity.Application.Queries;

public class GetAllRolesQuery : IRequest<ResultResponse<IEnumerable<RoleDto>>>
{
}

