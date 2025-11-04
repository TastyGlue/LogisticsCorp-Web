using LogisticsCorp.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LogisticsCorp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyInfoController
    {
        private readonly ICompanyInfo _service;

        public CompanyInfoController(ICompanyInfo service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.Get();
            return ApiResponseFactory.AdaptAndCreateResponse<CompanyInfo, CompanyInfoDTO>(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CompanyInfoDTO dto)
        {
            var result = await _service.Update(dto);
            return ApiResponseFactory.AdaptAndCreateResponse<CompanyInfo, CompanyInfoDTO>(result);
        }
    }
}
