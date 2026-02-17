namespace SecurityPoliceMG.Configuration;

public sealed class JwtSettings
{
    public string Audience { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Secret { get; set; } = string.Empty;
    public int AccessTokenExpirationMinutes { get; set; } = 0;
    public int RefreshTokenExpirationDays { get; set; } = 0;
}