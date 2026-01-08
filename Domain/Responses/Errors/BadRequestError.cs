namespace CryptoJackpot.Domain.Core.Responses.Errors;

public class BadRequestError(string message) : ApplicationError(message, 400);

