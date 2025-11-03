using LogisticsCorp.Web.Services.ApiServices.Interfaces;

namespace LogisticsCorp.Web.Services.ApiServices;

public class ApiAuthService : IApiAuthService
{
    private readonly HttpClientService _httpClientService;

    public ApiAuthService(HttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<CustomResult<string>> LoginWithCredentials(LoginCredentials request)
    {
        var client = _httpClientService.CreateApiClient();

        string apiEndpoint = "auth/login";

        var response = await client.PostAsJsonAsync(apiEndpoint, request);
        var content = await response.Content.ReadAsStringAsync();

        return CustomResultUtils.GetApiResponse<string>(response, content);
    }
}
