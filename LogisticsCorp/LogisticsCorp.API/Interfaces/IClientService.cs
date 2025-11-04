namespace LogisticsCorp.API.Interfaces
{
    public interface IClientService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(User user, Client client, string? password = null);
        Task<CustomResult> Update(Guid id, ClientDto clientDto);
        Task<CustomResult> Delete(Guid id);
    }
}
