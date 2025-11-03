using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface IAccountService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(AccountDto accountDto);
        Task<CustomResult> Update(Guid id, AccountDto accountDto);
        Task<CustomResult> Delete(Guid id);
    }
}
