using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiPricingRulesService
    {
        Task<CustomResult<IEnumerable<PricingRuleDto>>> GetAllPricingRules();
        Task<CustomResult<PricingRuleDto>> GetPricingRuleById(Guid id);
        Task<CustomResult<PricingRuleDto>> CreatePricingRule(PricingRuleDto dto);
        Task<CustomResult<PricingRuleDto>> UpdatePricingRule(Guid id, PricingRuleDto dto);
        Task<CustomResult<string>> DeletePricingRule(Guid id);
    }
}
