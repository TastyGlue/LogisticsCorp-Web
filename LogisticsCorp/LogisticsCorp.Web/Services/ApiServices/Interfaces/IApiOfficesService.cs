using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiOfficesService
    {
        Task<CustomResult<IEnumerable<OfficeDto>>> GetAllOffices();
        Task<CustomResult<OfficeDto>> GetOfficeById(Guid id);
        Task<CustomResult<OfficeDto>> CreateOffice(OfficeDto dto);
        Task<CustomResult<OfficeDto>> UpdateOffice(Guid id, OfficeDto dto);
        Task<CustomResult<string>> DeleteOffice(Guid id);
    }
}
