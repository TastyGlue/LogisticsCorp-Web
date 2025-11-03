using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiOfficeService
    {
        Task<CustomResult<IEnumerable<OfficeDto>>> GetAll();
        Task<CustomResult<OfficeDto>> Get(Guid id);
        Task<CustomResult<OfficeDto>> Create(OfficeDto dto);
        Task<CustomResult<OfficeDto>> Update(Guid id, OfficeDto dto);
        Task<CustomResult<string>> Delete(Guid id);
    }
}
