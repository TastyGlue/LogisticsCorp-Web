using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces;

public interface IApiAuthService
{
    Task<CustomResult<TokensResponse>> LoginWithCredentials(LoginCredentials request);
    Task<CustomResult<TokensResponse>> RefreshToken(RefreshTokenRequest request);
    Task<CustomResult<ClientDto>> Register(RegisterDto request);
}
