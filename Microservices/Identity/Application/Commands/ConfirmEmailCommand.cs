using CryptoJackpot.Domain.Core.Responses;
using MediatR;

namespace CryptoJackpot.Identity.Application.Commands;

public class ConfirmEmailCommand : IRequest<ResultResponse<string>>
{
    public string Token { get; set; } = null!;
}
