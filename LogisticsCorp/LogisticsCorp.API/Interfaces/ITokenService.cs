namespace LogisticsCorp.API.Interfaces;

public interface ITokenService
{
    /// <summary>
    /// Generates an access token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the access token is being generated. Cannot be null.</param>
    /// <returns>A <see cref="CustomResult{string}"/> containing the generated access token.</returns>
    CustomResult<string> GenerateAccessToken(User user);

    /// <summary>
    /// Generates a new refresh token for authentication purposes.
    /// </summary>
    /// <returns>A string representing the newly generated refresh token.</returns>
    string GenerateRefreshToken();
}