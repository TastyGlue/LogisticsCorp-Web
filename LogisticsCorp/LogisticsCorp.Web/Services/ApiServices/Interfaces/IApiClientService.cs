using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiClientService
    {
        Task<CustomResult<IEnumerable<ClientDto>>> GetAll();
        Task<CustomResult<ClientDto>> Get(Guid id);
        Task<CustomResult<ClientDto>> Create(ClientDto dto);
        Task<CustomResult<ClientDto>> Update(Guid id, ClientDto dto);
        Task<CustomResult<string>> Delete(Guid id);
    }
}
