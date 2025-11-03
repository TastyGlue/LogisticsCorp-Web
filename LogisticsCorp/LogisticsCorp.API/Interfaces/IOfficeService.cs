using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface IOfficeService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(OfficeDto officeDto);
        Task<CustomResult> Update(Guid id, OfficeDto officeDto);
        Task<CustomResult> Delete(Guid id);
    }
}
