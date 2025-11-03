using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface IEmployeeService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(EmployeeDto employeeDto);
        Task<CustomResult> Update(Guid id, EmployeeDto employeeDto);
        Task<CustomResult> Delete(Guid id);
    }
}
