using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.API.Interfaces
{
    public interface IEmployeeService
    {
        Task<CustomResult> Get(Guid id);
        Task<CustomResult> GetAll();
        Task<CustomResult> Create(User user, Employee employee, string? password = null);
        Task<CustomResult> Update(Guid id, EmployeeDto employeeDto);
        Task<CustomResult> Delete(Guid id);
    }
}
