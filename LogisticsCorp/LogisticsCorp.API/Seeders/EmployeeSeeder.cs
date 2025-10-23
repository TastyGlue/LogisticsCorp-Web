namespace LogisticsCorp.API.Seeders;

public class EmployeeSeeder : IDataSeeder
{
    private readonly IUserService _userService;
    private readonly UserManager<User> _userManager;

    public EmployeeSeeder(IUserService userService, UserManager<User> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    public int Order => 4;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<Employee>("Seeds/EmployeeSeedData.json");

        foreach (var employee in data)
        {
            if (await context.Set<Employee>().AnyAsync(e => e.Id == employee.Id)) continue;

            // Add employee (which will also add the nested User via EF Core)
            employee.User.SecurityStamp = Guid.NewGuid().ToString(); // Ensure unique SecurityStamp
            context.Set<Employee>().Add(employee);
            await context.SaveChangesAsync();

            // After successful creation, assign user to EMPLOYEE role
            var roleResult = await _userService.AddUserToRole(employee.UserId, SeedConstants.ROLE_EMPLOYEE_NAME, overwriteExisting: false);
            if (!roleResult.Succeeded)
            {
                throw new Exception($"Failed to assign {SeedConstants.ROLE_EMPLOYEE_NAME} role to user '{employee.UserId}': {roleResult.Error?.Message}");
            }

            // Reset password to default
            var user = await _userManager.FindByIdAsync(employee.UserId.ToString());
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var resetResult = await _userManager.ResetPasswordAsync(user, token, Constants.DEFAULT_PASSWORD);
                if (!resetResult.Succeeded)
                {
                    var errors = string.Join(", ", resetResult.Errors.Select(e => e.Description));
                    throw new Exception($"Failed to reset password for user '{user.UserName}': {errors}");
                }
            }
        }
    }
}
