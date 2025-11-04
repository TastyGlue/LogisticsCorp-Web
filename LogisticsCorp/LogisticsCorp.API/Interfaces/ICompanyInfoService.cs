using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface ICompanyInfoService
    {
        Task<CustomResult> Get();
        Task<CustomResult> Update(CompanyInfoDTO employeeDto);
    }
}
