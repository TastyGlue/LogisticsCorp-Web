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
}
