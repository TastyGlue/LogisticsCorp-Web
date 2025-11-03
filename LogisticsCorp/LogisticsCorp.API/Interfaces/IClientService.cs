using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface IClientService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(ClientDto clientDto);
        Task<CustomResult> Update(Guid id, ClientDto clientDto);
        Task<CustomResult> Delete(Guid id);
    }
}
