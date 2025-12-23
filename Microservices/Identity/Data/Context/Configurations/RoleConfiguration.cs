using CryptoJackpot.Domain.Core.Constants;
using CryptoJackpot.Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoJackpot.Identity.Data.Context.Configurations;

public class RoleConfiguration:IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasColumnType(ColumnTypes.Text).HasMaxLength(100);
        builder.Property(e => e.Description).HasColumnType(ColumnTypes.Text).HasMaxLength(200);
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();
            
        builder.HasQueryFilter(e => !e.DeletedAt.HasValue);
    }
}