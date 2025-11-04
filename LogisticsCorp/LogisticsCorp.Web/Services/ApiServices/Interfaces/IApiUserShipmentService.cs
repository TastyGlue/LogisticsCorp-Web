using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiUserShipmentService
    {
        Task<CustomResult<IEnumerable<ShipmentDto>>> GetAll(Guid id);
    }
}
