namespace LogisticsCorp.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly LogisticsCorpDbContext _context;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;

        public EmployeeService(LogisticsCorpDbContext context, IUserService userService, UserManager<User> userManager)
        {
            _context = context;
            _userService = userService;
            _userManager = userManager;
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
                .Include(e => e.User)
                .ToListAsync();

            return new CustomResult<IEnumerable<Employee>>(employees);
        }

        public async Task<CustomResult> Create(User user, Employee employee, string? password = null)
        {
            // Create User
            var createUser = await _userManager.CreateAsync(user, password ?? Constants.DEFAULT_PASSWORD);
            if (!createUser.Succeeded)
            {
                var errors = string.Join(", ", createUser.Errors.Select(e => e.Description));
                return new(new ErrorResult(errors, ErrorCodes.USER_CREATE_FAILED));
            }

            // Get new created User
            var newUser = await _userManager.FindByEmailAsync(user.Email!);

            // Add User to EMPLOYEE role
            var addToRoleResult = await _userService.AddUserToRole(newUser!.Id, SeedConstants.ROLE_EMPLOYEE_NAME, overwriteExisting: true);
            if (!addToRoleResult.Succeeded)
            {
                await _userManager.DeleteAsync(newUser);
                return addToRoleResult;
            }

            // Create Employee linked to the new User
            employee.UserId = newUser!.Id;
            employee.User = null!; // Avoid EF Core trying to insert the User again
            await _context.Employees.AddAsync(employee);

            try
            {
                await _context.SaveChangesAsync();

                newUser.AccountId = employee.Id;
                await _userManager.UpdateAsync(newUser);
            }
            catch (Exception)
            {
                await _userManager.DeleteAsync(newUser);
                throw;
            }

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
