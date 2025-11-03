using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices
{
    public class ApiPricingRuleService : IApiPricingRuleService
    {
        private readonly HttpClientService _httpClientService;
        private readonly TokenService _tokenService;

        public ApiPricingRuleService(HttpClientService httpClientService, TokenService tokenService)
        {
            _httpClientService = httpClientService;
            _tokenService = tokenService;
        }

        public async Task<CustomResult<PricingRuleDto>> CreatePricingRule(PricingRuleDto dto)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.PostAsJsonAsync("api/pricingrules", dto);
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<PricingRuleDto>(response, content);
        }

        public async Task<CustomResult<PricingRuleDto>> UpdatePricingRule(Guid id, PricingRuleDto dto)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.PutAsJsonAsync($"api/pricingrules/{id}", dto);
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<PricingRuleDto>(response, content);
        }

        public async Task<CustomResult<string>> DeletePricingRule(Guid id)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.DeleteAsync($"api/pricingrules/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<string>(response, content);
        }

        public async Task<CustomResult<IEnumerable<PricingRuleDto>>> GetAllPricingRules()
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.GetAsync("api/pricingrules");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<IEnumerable<PricingRuleDto>>(response, content);
        }

        public async Task<CustomResult<PricingRuleDto>> GetPricingRule(Guid id)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.GetAsync($"api/pricingrules/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<PricingRuleDto>(response, content);
        }
    }
}
