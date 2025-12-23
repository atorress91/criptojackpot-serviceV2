namespace CryptoJackpot.Domain.Core.Constants;

/// <summary>
/// PostgreSQL column type constants for Entity Framework configurations.
/// Shared across all microservices.
/// </summary>
public static class ColumnTypes
{
    public const string Decimal = "decimal(18,2)";
    public const string Text = "text";
    public const string Jsonb = "jsonb";
    public const string Timestamp = "timestamp with time zone";
    public const string Boolean = "boolean";
    public const string Integer = "integer";
    public const string BigInt = "bigint";
}

