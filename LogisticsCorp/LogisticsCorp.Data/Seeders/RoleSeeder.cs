namespace LogisticsCorp.Data.Seeders;

public class RoleSeeder : IDataSeeder
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    public RoleSeeder(RoleManager<IdentityRole<Guid>> roleManager)
    {
        _roleManager = roleManager;
    }

    public int Order => 1;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<IdentityRole<Guid>>("Seeds/RoleSeedData.json");

        foreach (var role in data)
        {
            if (await _roleManager.RoleExistsAsync(role.Name!)) continue;
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create role '{role.Name}': {errors}");
            }
        }
    }
}
