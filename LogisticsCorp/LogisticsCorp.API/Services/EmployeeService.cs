using LogisticsCorp.Data.Models;
using LogisticsCorp.Shared.Models.DTOs;
using MapsterMapper;

namespace LogisticsCorp.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly LogisticsCorpDbContext _context;

        public EmployeeService(LogisticsCorpDbContext context)
        {
            _context = context;
        }

        public async Task<CustomResult> Get(Guid id)
        {
            var employee = await _context.Employees
                .Include(e => e.Office)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (employee == null)
                return new CustomResult(new ErrorResult($"Employee with ID {id} not found.", ErrorCodes.ENTITY_NOT_FOUND));

            return new CustomResult<Employee>(employee);
        }

        public async Task<CustomResult> GetAll()
        {
            var employees = await _context.Employees
                .Include(e => e.Office)
                .ToListAsync();

            return new CustomResult<IEnumerable<Employee>>(employees);
        }

        public async Task<CustomResult> Create(EmployeeDto dto)
        {
            var employee = dto.Adapt<Employee>();
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return new CustomResult<Employee>(employee);
        }

        public async Task<CustomResult> Update(Guid id, EmployeeDto dto)
        {
            if (id != dto.Id)
                return new CustomResult(new ErrorResult("Mismatching ids", ErrorCodes.ENTITY_MISMATCH_ID));

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return new CustomResult(new ErrorResult("Employee not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Entry(employee).CurrentValues.SetValues(dto);
            await _context.SaveChangesAsync();

            return new CustomResult<Employee>(employee);
        }

        public async Task<CustomResult> Delete(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return new CustomResult(new ErrorResult("Employee not found", ErrorCodes.ENTITY_NOT_FOUND));

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return new CustomResult<string>("Deleted successfully!");
        }
    }
}
