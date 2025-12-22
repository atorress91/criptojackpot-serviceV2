namespace CryptoJackpot.Notification.Application.DTOs;

public sealed record ResultResponse<T>
{
    public bool Success { get; init; }
    public T? Data { get; init; }
    public string? Message { get; init; }

    public static ResultResponse<T> Ok(T? data = default) =>
        new() { Success = true, Data = data };

    public static ResultResponse<T> Failure(string message) =>
        new() { Success = false, Message = message };
}
