namespace LogisticsCorp.Web.Services.ApiServices;

public class ApiAuthService : IApiAuthService
{
    private readonly HttpClientService _httpClientService;

    public ApiAuthService(HttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<CustomResult<TokensResponse>> LoginWithCredentials(LoginCredentials request)
    {
        var client = _httpClientService.CreateApiClient();

        string apiEndpoint = "api/auth/login";

        var response = await client.PostAsJsonAsync(apiEndpoint, request);
        var content = await response.Content.ReadAsStringAsync();

        return CustomResultUtils.GetApiResponse<TokensResponse>(response, content);
    }

    public async Task<CustomResult<TokensResponse>> RefreshToken(RefreshTokenRequest request)
    {
        var client = _httpClientService.CreateApiClient();

        string apiEndpoint = "api/auth/refresh";

        var response = await client.PostAsJsonAsync(apiEndpoint, request);
        var content = await response.Content.ReadAsStringAsync();

        return CustomResultUtils.GetApiResponse<TokensResponse>(response, content);
    }

    public async Task<CustomResult<ClientDto>> Register(RegisterDto request)
    {
        var client = _httpClientService.CreateApiClient();

        string apiEndpoint = "api/auth/register";

        var response = await client.PostAsJsonAsync(apiEndpoint, request);
        var content = await response.Content.ReadAsStringAsync();

        return CustomResultUtils.GetApiResponse<ClientDto>(response, content);
    }
}
