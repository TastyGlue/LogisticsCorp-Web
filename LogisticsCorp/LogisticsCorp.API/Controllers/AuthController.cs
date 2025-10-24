using Microsoft.AspNetCore.Mvc;

namespace LogisticsCorp.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    /// <summary>
    /// Authenticates a user with email and password credentials.
    /// </summary>
    /// <param name="credentials">The login credentials containing email and password.</param>
    /// <returns>An access token if authentication is successful; otherwise, an error response.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginCredentials credentials)
    {
        var result = await _authService.LoginWithCredentials(credentials);
        return ApiResponseFactory.CreateResponse<TokensResponse>(result);
    }

    /// <summary>
    /// Refreshes an access token using a valid refresh token.
    /// </summary>
    /// <param name="request">The refresh token request containing the refresh token.</param>
    /// <returns>New access and refresh tokens if the refresh token is valid; otherwise, an error response.</returns>
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
    {
        var result = await _authService.RefreshToken(request.RefreshToken);
        return ApiResponseFactory.CreateResponse<TokensResponse>(result);
    }
}
