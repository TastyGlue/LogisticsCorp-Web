namespace LogisticsCorp.API.Seeders;

public class AdminSeeder : IDataSeeder
{
    private readonly IUserService _userService;
    private readonly UserManager<User> _userManager;

    public AdminSeeder(IUserService userService, UserManager<User> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    public int Order => 100;

    public async Task Seed(DbContext context)
    {
        var admin = new Employee()
        {
            Id = new Guid("30000000-0000-0000-0000-100000000000"),
            UserId = new Guid("301792e0-fbfb-4642-86f7-9bf5d3f68468"),
            OfficeId = new Guid("33333333-3333-3333-3333-333333333333"),
            EmployeeType = EmployeeType.OfficeStaff,
            HireDate = new DateTime(2023, 1, 5, 0, 0, 0, DateTimeKind.Utc),
            Salary = 80000m,
            User = new User()
            {
                Id = new Guid("301792e0-fbfb-4642-86f7-9bf5d3f68468"),
                UserName = "admin.admin@example.com",
                Email = "admin.admin@example.com",
                FullName = "Admin Admin",
                IsActive = true,
                EmailConfirmed = true
            }
        };

        if (await context.Set<Employee>().AnyAsync(e => e.Id == admin.Id)) return;
        
        // Add employee (which will also add the nested User via EF Core)
        admin.User.SecurityStamp = Guid.NewGuid().ToString(); // Ensure unique SecurityStamp
        context.Set<Employee>().Add(admin);
        await context.SaveChangesAsync();

        // After successful creation, assign user to ADMIN role
        var roleResult = await _userService.AddUserToRole(admin.UserId, SeedConstants.ROLE_ADMIN_NAME, overwriteExisting: false);
        if (!roleResult.Succeeded)
        {
            throw new Exception($"Failed to assign {SeedConstants.ROLE_EMPLOYEE_NAME} role to user '{admin.UserId}': {roleResult.Error?.Message}");
        }

        // Reset password to default
        var user = await _userManager.FindByIdAsync(admin.UserId.ToString());
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
