namespace LogisticsCorp.Shared.Models;

/// <summary>
/// Represents a request to refresh an access token.
/// </summary>
/// <param name="RefreshToken">The refresh token used to obtain a new access token.</param>
public record RefreshTokenRequest(string RefreshToken);
