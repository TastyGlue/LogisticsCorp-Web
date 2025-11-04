using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices
{
    public class ApiUserShipmentService : IApiUserShipmentService
    {
        private readonly HttpClientService _httpClientService;
        private readonly TokenService _tokenService;
        public ApiUserShipmentService(HttpClientService httpClientService, TokenService tokenService)
        {
            _httpClientService = httpClientService;
            _tokenService = tokenService;
        }
        public async Task<CustomResult<IEnumerable<ShipmentDto>>> GetAll(Guid id)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.GetAsync($"api/usershipment/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<IEnumerable<ShipmentDto>>(response, content);
        }
    }
}
