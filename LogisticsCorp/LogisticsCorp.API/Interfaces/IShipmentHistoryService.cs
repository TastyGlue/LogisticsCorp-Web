using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface IShipmentHistoryService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(ShipmentHistoryDto shipmentHistoryDto);
        Task<CustomResult> Update(Guid id, ShipmentHistoryDto shipmentHistoryDto);
        Task<CustomResult> Delete(Guid id);
    }
}
