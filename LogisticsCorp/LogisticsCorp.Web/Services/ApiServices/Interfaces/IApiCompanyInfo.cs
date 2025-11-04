using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    
    public interface IApiCompanyInfo
    {
        Task<CustomResult<CompanyInfoDTO>> Get();
        Task<CustomResult<CompanyInfoDTO>> Update(CompanyInfoDTO dto);
    }
}
