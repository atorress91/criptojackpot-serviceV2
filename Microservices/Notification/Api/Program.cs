using CryptoJackpot.Notification.Application;
using CryptoJackpot.Notification.Application.Configuration;
using CryptoJackpot.Notification.Application.Interfaces;
using CryptoJackpot.Notification.Api.Providers;
using CryptoJackpot.Notification.Data.Context;
using CryptoJackpot.Notification.Data.Repositories;
using CryptoJackpot.Notification.Domain.Interfaces;
using CryptoJackpot.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration
builder.Services.Configure<NotificationConfiguration>(builder.Configuration);

// Database
builder.Services.AddDbContext<NotificationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repositories
builder.Services.AddScoped<INotificationLogRepository, NotificationLogRepository>();

// Providers
builder.Services.AddScoped<IEmailProvider, SmtpEmailProvider>();
builder.Services.AddSingleton<IEmailTemplateProvider, FileEmailTemplateProvider>();

// Application Layer (MediatR, Services, Handlers)
builder.Services.AddNotificationApplication();

// Register Infra.IoC Dependency Container (Bus, Kafka)
DependencyContainer.RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

