using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices
{
    public class ApiShipmentService : IApiShipmentService
    {
        private readonly HttpClientService _httpClientService;
        private readonly TokenService _tokenService;

        public ApiShipmentService(HttpClientService httpClientService, TokenService tokenService)
        {
            _httpClientService = httpClientService;
            _tokenService = tokenService;
        }

        public async Task<CustomResult<ShipmentDto>> Create(ShipmentDto dto)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.PostAsJsonAsync("api/shipments", dto);
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<ShipmentDto>(response, content);
        }

        public async Task<CustomResult<ShipmentDto>> Update(Guid id, ShipmentDto dto)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.PutAsJsonAsync($"api/shipments/{id}", dto);
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<ShipmentDto>(response, content);
        }

        public async Task<CustomResult<string>> Delete(Guid id)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.DeleteAsync($"api/shipments/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<string>(response, content);
        }

        public async Task<CustomResult<IEnumerable<ShipmentDto>>> GetAll()
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.GetAsync("api/shipments");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<IEnumerable<ShipmentDto>>(response, content);
        }

        public async Task<CustomResult<ShipmentDto>> Get(Guid id)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);
            var response = await client.GetAsync($"api/shipments/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<ShipmentDto>(response, content);
        }
    }
}
