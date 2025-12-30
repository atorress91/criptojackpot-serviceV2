using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace CryptoJackpot.Winner.Data.Context;

public class WinnerDbContext : DbContext
{
    public WinnerDbContext(DbContextOptions<WinnerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // MassTransit Outbox configuration with snake_case naming
        modelBuilder.AddInboxStateEntity(x => x.ToTable("inbox_state"));
        modelBuilder.AddOutboxMessageEntity(x => x.ToTable("outbox_message"));
        modelBuilder.AddOutboxStateEntity(x => x.ToTable("outbox_state"));
    }
}
