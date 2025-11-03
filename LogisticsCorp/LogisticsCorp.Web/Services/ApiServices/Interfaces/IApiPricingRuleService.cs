using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiPricingRuleService
    {
        Task<CustomResult<IEnumerable<PricingRuleDto>>> GetAll();
        Task<CustomResult<PricingRuleDto>> Get(Guid id);
        Task<CustomResult<PricingRuleDto>> Create(PricingRuleDto dto);
        Task<CustomResult<PricingRuleDto>> Update(Guid id, PricingRuleDto dto);
        Task<CustomResult<string>> Delete(Guid id);
    }
}
