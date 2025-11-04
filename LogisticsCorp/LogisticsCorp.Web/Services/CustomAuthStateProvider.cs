using System.Security.Claims;

namespace LogisticsCorp.Web.Services;

public class CustomAuthStateProvider : AuthenticationStateProvider
{
    private readonly ProtectedLocalStorage _localStorage;
    private readonly JwtSettings _jwtSettings;
    private readonly NavigationManager _navigationManager;
    private readonly IApiAuthService _apiAuthService;

    public CustomAuthStateProvider(ProtectedLocalStorage localStorage, IOptions<JwtSettings> jwtSettingsOptions, NavigationManager navigationManager, IApiAuthService apiAuthService)
    {
        _localStorage = localStorage;
        _jwtSettings = jwtSettingsOptions.Value;
        _navigationManager = navigationManager;
        _apiAuthService = apiAuthService;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var accessToken = (await _localStorage.GetAsync<string>(Constants.ACCESS_TOKEN_KEY)).Value;

        var identity = new ClaimsIdentity();

        if (!string.IsNullOrWhiteSpace(accessToken))
        {
            var claims = TokenUtils.ParseClaimsFromToken(accessToken);

            if (TokenUtils.ValidateToken(accessToken, _jwtSettings.SecurityKey))
            {
                identity = new ClaimsIdentity(claims, "jwtAuth");
            }
            else
            {
                // Attempt to refresh the token
                if (await TryRefreshToken(accessToken, new ClaimsIdentity(claims)))
                {
                    accessToken = (await _localStorage.GetAsync<string>(Constants.ACCESS_TOKEN_KEY)).Value; // Get new token
                    claims = TokenUtils.ParseClaimsFromToken(accessToken!);
                    identity = new ClaimsIdentity(claims, "jwtAuth");
                }
                else
                {
                    // Redirect to login if refresh token is also expired
                    _navigationManager.NavigateTo("/account/login");
                }
            }
        }

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    private async Task<bool> TryRefreshToken(string accessToken, ClaimsIdentity identity)
    {
        // Check if the token is expired
        var isTokenExpired = TokenUtils.IsTokenExpired(new ClaimsPrincipal(identity), TimeSpan.FromDays(_jwtSettings.RefreshTokenExpirationDays));
        if (isTokenExpired is null)
            return false;

        // Check if the refresh token expiration is still valid
        if (!isTokenExpired.Value)
        {
            // Get Refresh Token from LocalStorage
            var refreshToken = (await _localStorage.GetAsync<string>(Constants.REFRESH_TOKEN_KEY)).Value;
            if (refreshToken is null)
                return false;

            // Call the API to refresh the token
            var request = new RefreshTokenRequest(refreshToken);
            var result = await _apiAuthService.RefreshToken(request);

            if (result.Succeeded)
            {
                var tokens = result.Value!;

                // Store the new tokens in LocalStorage
                await _localStorage.SetAsync(Constants.ACCESS_TOKEN_KEY, tokens.AccessToken);
                await _localStorage.SetAsync(Constants.REFRESH_TOKEN_KEY, tokens.RefreshToken);

                return true; // Successfully refreshed token
            }
        }

        return false;
    }
}
