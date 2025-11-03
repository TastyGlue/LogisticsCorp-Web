using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface IShipmentService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(ShipmentDto shipmentDto);
        Task<CustomResult> Update(Guid id, ShipmentDto shipmentDto);
        Task<CustomResult> Delete(Guid id);
    }
}
