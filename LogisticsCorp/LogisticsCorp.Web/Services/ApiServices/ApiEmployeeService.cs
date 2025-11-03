using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices
{
    public class ApiEmployeeService : IApiEmployeeService
    {
        private readonly HttpClientService _httpClientService;
        private readonly TokenService _tokenService;

        public ApiEmployeeService(HttpClientService httpClientService, TokenService tokenService)
        {
            _httpClientService = httpClientService;
            _tokenService = tokenService;
        }

        public async Task<CustomResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);

            var response = await client.GetAsync("api/employees");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<IEnumerable<EmployeeDto>>(response, content);
        }

        public async Task<CustomResult<EmployeeDto>> Get(Guid id)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);

            var response = await client.GetAsync($"api/employees/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<EmployeeDto>(response, content);
        }

        public async Task<CustomResult<EmployeeDto>> Create(EmployeeDto dto)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);

            var response = await client.PostAsJsonAsync("api/employees", dto);
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<EmployeeDto>(response, content);
        }

        public async Task<CustomResult<EmployeeDto>> Update(Guid id, EmployeeDto dto)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);

            var response = await client.PutAsJsonAsync($"api/employees/{id}", dto);
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<EmployeeDto>(response, content);
        }

        public async Task<CustomResult<string>> Delete(Guid id)
        {
            var token = await _tokenService.GetToken(Constants.ACCESS_TOKEN_KEY);
            var client = _httpClientService.CreateApiClient(token);

            var response = await client.DeleteAsync($"api/employees/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return CustomResultUtils.GetApiResponse<string>(response, content);
        }
    }
}
