using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices
{
    public class ApiCompanyInfoService : IApiCompanyInfo
    {
        private readonly HttpClientService _httpClientService;
        private readonly TokenService _tokenService;

        public ApiCompanyInfoService(HttpClientService httpClientService, TokenService tokenService)
        {
            _httpClientService = httpClientService;
            _tokenService = tokenService;
        }

        public async Task<CustomResult<CompanyInfoDTO>> Get()
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);

            var response = await client.GetAsync($"api/companyinfo");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<CompanyInfoDTO>(response, content);
        }

        public async Task<CustomResult<CompanyInfoDTO>> Update(CompanyInfoDTO dto)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);

            var response = await client.PutAsJsonAsync($"api/companyinfo", dto);
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<CompanyInfoDTO>(response, content);
        }
    }
}
