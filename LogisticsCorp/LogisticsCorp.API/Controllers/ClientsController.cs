using Microsoft.AspNetCore.Mvc;
using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAll();
            return ApiResponseFactory.AdaptAndCreateResponse<IEnumerable<Client>, IEnumerable<ClientDto>>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return ApiResponseFactory.AdaptAndCreateResponse<Client, ClientDto>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClientDto dto)
        {
            var user = dto.User.Adapt<User>();
            var client = dto.Adapt<Client>();
            var result = await _service.Create(user, client);
            return ApiResponseFactory.AdaptAndCreateResponse<Client, ClientDto>(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClientDto dto)
        {
            var result = await _service.Update(id, dto);
            return ApiResponseFactory.AdaptAndCreateResponse<Client, ClientDto>(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            return ApiResponseFactory.CreateResponse<string>(result);
        }
    }
}
