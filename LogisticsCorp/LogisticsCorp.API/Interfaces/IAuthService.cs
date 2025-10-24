namespace LogisticsCorp.API.Interfaces;

public interface IAuthService
{
    /// <summary>
    /// Authenticates a user using the provided login credentials.
    /// </summary>
    /// <remarks>This method performs an asynchronous login operation. Ensure that the credentials provided
    /// are valid and that the user has the necessary permissions.</remarks>
    /// <param name="credentials">The login credentials containing the username and password required for authentication. Cannot be null.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CustomResult{T}"/> with
    /// a <see cref="TokensResponse"/> if authentication is successful.</returns>
    Task<CustomResult<TokensResponse>> LoginWithCredentials(LoginCredentials credentials);

    /// <summary>
    /// Refreshes the authentication tokens using the provided refresh token.
    /// </summary>
    /// <remarks>This method initiates a token refresh operation, which is used to maintain user
    /// authentication without requiring re-login. Ensure that the refresh token is valid and has not expired.</remarks>
    /// <param name="refreshToken">The refresh token used to obtain new authentication tokens. Cannot be null or empty.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CustomResult{T}"/> with
    /// the new <see cref="TokensResponse"/>.</returns>
    Task<CustomResult<TokensResponse>> RefreshToken(string refreshToken);
}
