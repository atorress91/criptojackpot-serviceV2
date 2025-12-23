using CryptoJackpot.Domain.Core.Constants;
using CryptoJackpot.Identity.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CryptoJackpot.Identity.Data.Context.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Name).IsRequired().HasColumnType(ColumnTypes.Text).HasMaxLength(100);
        builder.Property(e => e.Description).HasColumnType(ColumnTypes.Text).HasMaxLength(255);
        builder.Property(e => e.Module).IsRequired().HasColumnType(ColumnTypes.Text).HasMaxLength(50);
        builder.Property(e => e.CreatedAt).IsRequired();
        builder.Property(e => e.UpdatedAt).IsRequired();
        
        // Indexes
        builder.HasIndex(e => new { e.Name, e.Module }).IsUnique();
        
        // Soft delete filter
        builder.HasQueryFilter(e => !e.DeletedAt.HasValue);
    }
}

