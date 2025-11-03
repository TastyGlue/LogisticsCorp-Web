using Microsoft.AspNetCore.Mvc;
using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        //// GET: api/Users
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await _service.GetAll();
        //    return ApiResponseFactory.AdaptAndCreateResponse<IEnumerable<User>, IEnumerable<UserDto>>(result);
        //}

        //// GET: api/Users/{id}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var result = await _service.Get(id);
        //    return ApiResponseFactory.AdaptAndCreateResponse<User, UserDto>(result);
        //}

        //// POST: api/Users
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] UserDto dto)
        //{
        //    var result = await _service.Create(dto);
        //    return ApiResponseFactory.AdaptAndCreateResponse<User, UserDto>(result);
        //}

        //// PUT: api/Users/{id}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, [FromBody] UserDto dto)
        //{
        //    var result = await _service.Update(id, dto);
        //    return ApiResponseFactory.AdaptAndCreateResponse<User, UserDto>(result);
        //}

        //// DELETE: api/Users/{id}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var result = await _service.Delete(id);
        //    return ApiResponseFactory.CreateResponse<string>(result);
        //}

        // POST: api/Users/{id}/roles
        //[HttpPost("{id}/roles")]
        //public async Task<IActionResult> AddToRole(Guid id, [FromQuery] string roleName, [FromQuery] bool overwriteExisting = false)
        //{
        //    var result = await _service.AddUserToRole(id, roleName, overwriteExisting);
        //    return ApiResponseFactory.CreateResponse<string>(result);
        //}
    }
}
