namespace LogisticsCorp.Shared.Models;

public class JwtSettings
{
    public string SecurityKey { get; set; } = default!;

    public int AccessTokenExpirationMinutes { get; set; }

    public int RefreshTokenExpirationDays { get; set; }
}