using CryptoJackpot.Notification.Application;

var builder = WebApplication.CreateBuilder(args);

// Single point of DI configuration
builder.Services.AddNotificationServices(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
