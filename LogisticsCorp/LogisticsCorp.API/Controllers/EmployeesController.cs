using Microsoft.AspNetCore.Mvc;
using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAll();
            return ApiResponseFactory.AdaptAndCreateResponse<IEnumerable<Employee>, IEnumerable<EmployeeDto>>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return ApiResponseFactory.AdaptAndCreateResponse<Employee, EmployeeDto>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmployeeDto dto)
        {
            var user = dto.User.Adapt<User>();
            user.UserName = user.Email + Guid.NewGuid().ToString();
            var employee = dto.Adapt<Employee>();

            var result = await _service.Create(user, employee);
            return ApiResponseFactory.AdaptAndCreateResponse<Employee, EmployeeDto>(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] EmployeeDto dto)
        {
            var result = await _service.Update(id, dto);
            return ApiResponseFactory.AdaptAndCreateResponse<Employee, EmployeeDto>(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            return ApiResponseFactory.CreateResponse<string>(result);
        }
    }
}
