using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiEmployeeService
    {
        Task<CustomResult<IEnumerable<EmployeeDto>>> GetAll();
        Task<CustomResult<EmployeeDto>> Get(Guid id);
        Task<CustomResult<EmployeeDto>> Create(EmployeeDto dto);
        Task<CustomResult<EmployeeDto>> Update(Guid id, EmployeeDto dto);
        Task<CustomResult<string>> Delete(Guid id);
    }
}
