namespace LogisticsCorp.API.Seeders;

public class EmployeeSeeder : IDataSeeder
{
    private readonly IUserService _userService;

    public EmployeeSeeder(IUserService userService)
    {
        _userService = userService;
    }

    public int Order => 5;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<Employee>("Seeds/EmployeeSeedData.json");

        foreach (var employee in data)
        {
            if (await context.Set<Employee>().AnyAsync(e => e.Id == employee.Id)) continue;

            // Assign user to EMPLOYEE role first
            var result = await _userService.AddUserToRole(employee.UserId, SeedConstants.ROLE_EMPLOYEE_NAME, overwriteExisting: false);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to assign {SeedConstants.ROLE_EMPLOYEE_NAME} role to user '{employee.UserId}': {result.Error?.Message}");
            }

            // Only add employee to database if role assignment succeeded
            context.Set<Employee>().Add(employee);
        }

        await context.SaveChangesAsync();
    }
}
