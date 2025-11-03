using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiClientsService
    {
        Task<CustomResult<IEnumerable<ClientDto>>> GetAllClients();
        Task<CustomResult<ClientDto>> GetClientById(Guid id);
        Task<CustomResult<ClientDto>> CreateClient(ClientDto dto);
        Task<CustomResult<ClientDto>> UpdateClient(Guid id, ClientDto dto);
        Task<CustomResult<string>> DeleteClient(Guid id);
    }
}
