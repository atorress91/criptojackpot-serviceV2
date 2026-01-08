namespace CryptoJackpot.Domain.Core.Responses.Errors;

public class UnauthorizedError(string message) : ApplicationError(message, 401);

