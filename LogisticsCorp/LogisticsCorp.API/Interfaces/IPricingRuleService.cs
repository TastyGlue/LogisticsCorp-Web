using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface IPricingRuleService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(PricingRuleDto pricingRuleDto);
        Task<CustomResult> Update(Guid id, PricingRuleDto pricingRuleDto);
        Task<CustomResult> Delete(Guid id);
    }
}
