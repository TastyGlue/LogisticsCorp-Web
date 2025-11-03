using Microsoft.AspNetCore.Mvc;
using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeService _service;

        public OfficesController(IOfficeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAll();
            return ApiResponseFactory.AdaptAndCreateResponse<IEnumerable<Office>, IEnumerable<OfficeDto>>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return ApiResponseFactory.AdaptAndCreateResponse<Office, OfficeDto>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OfficeDto dto)
        {
            var result = await _service.Create(dto);
            return ApiResponseFactory.AdaptAndCreateResponse<Office, OfficeDto>(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] OfficeDto dto)
        {
            var result = await _service.Update(id, dto);
            return ApiResponseFactory.AdaptAndCreateResponse<Office, OfficeDto>(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            return ApiResponseFactory.CreateResponse<string>(result);
        }
    }
}
