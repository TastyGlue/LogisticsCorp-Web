using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Services.ApiServices.Interfaces
{
    public interface IApiEmployeesService
    {
        Task<CustomResult<IEnumerable<EmployeeDto>>> GetAllEmployees();
        Task<CustomResult<EmployeeDto>> GetEmployeeById(Guid id);
        Task<CustomResult<EmployeeDto>> CreateEmployee(EmployeeDto dto);
        Task<CustomResult<EmployeeDto>> UpdateEmployee(Guid id, EmployeeDto dto);
        Task<CustomResult<string>> DeleteEmployee(Guid id);
    }
}
