using LogisticsCorp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserShipmentController : Controller
    {
        
        private readonly IUserShipmentService _service;

        public UserShipmentController(IUserShipmentService service)
        {
            _service = service;
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAll(Guid id)
        {
            var result = await _service.GetAll(id);
            return ApiResponseFactory.AdaptAndCreateResponse<IEnumerable<Shipment>, IEnumerable<ShipmentDto>>(result);
        }
    }
}
