using Microsoft.AspNetCore.Mvc;
using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _service;

        public ShipmentsController(IShipmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAll();
            return ApiResponseFactory.AdaptAndCreateResponse<IEnumerable<Shipment>, IEnumerable<ShipmentDto>>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return ApiResponseFactory.AdaptAndCreateResponse<Shipment, ShipmentDto>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ShipmentDto dto)
        {
            var result = await _service.Create(dto);
            return ApiResponseFactory.AdaptAndCreateResponse<Shipment, ShipmentDto>(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ShipmentDto dto)
        {
            var result = await _service.Update(id, dto);
            return ApiResponseFactory.AdaptAndCreateResponse<Shipment, ShipmentDto>(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            return ApiResponseFactory.CreateResponse<string>(result);
        }
    }
}
