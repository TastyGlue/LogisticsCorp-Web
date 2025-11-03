using Microsoft.AspNetCore.Mvc;
using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingRulesController : ControllerBase
    {
        private readonly IPricingRuleService _service;

        public PricingRulesController(IPricingRuleService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAll();
            return ApiResponseFactory.AdaptAndCreateResponse<IEnumerable<PricingRule>, IEnumerable<PricingRuleDto>>(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _service.Get(id);
            return ApiResponseFactory.AdaptAndCreateResponse<PricingRule, PricingRuleDto>(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PricingRuleDto dto)
        {
            var result = await _service.Create(dto);
            return ApiResponseFactory.AdaptAndCreateResponse<PricingRule, PricingRuleDto>(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] PricingRuleDto dto)
        {
            var result = await _service.Update(id, dto);
            return ApiResponseFactory.AdaptAndCreateResponse<PricingRule, PricingRuleDto>(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.Delete(id);
            return ApiResponseFactory.CreateResponse<string>(result);
        }
    }
}
