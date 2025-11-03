using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiShipmentService
    {
        Task<CustomResult<IEnumerable<ShipmentDto>>> GetAll();
        Task<CustomResult<ShipmentDto>> Get(Guid id);
        Task<CustomResult<ShipmentDto>> Create(ShipmentDto dto);
        Task<CustomResult<ShipmentDto>> Update(Guid id, ShipmentDto dto);
        Task<CustomResult<string>> Delete(Guid id);
    }
}
