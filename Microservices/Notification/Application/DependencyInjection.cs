using CryptoJackpot.Notification.Application.Handlers;
using CryptoJackpot.Notification.Application.Interfaces;
using CryptoJackpot.Notification.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoJackpot.Notification.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddNotificationApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(SendEmailConfirmationHandler).Assembly));
        services.AddScoped<INotificationService, NotificationService>();
        return services;
    }
}
