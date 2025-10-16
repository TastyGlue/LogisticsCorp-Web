namespace LogisticsCorp.Data.Seeders;

public class UserSeeder : IDataSeeder
{
    private readonly UserManager<User> _userManager;

    public UserSeeder(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public int Order => 2;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<User>("Seeds/UserSeedData.json");

        foreach (var user in data)
        {
            if (await _userManager.FindByIdAsync(user.Id.ToString()) != null) continue;
            var result = await _userManager.CreateAsync(user, Constants.DEFAULT_PASSWORD);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new Exception($"Failed to create user '{user.UserName}': {errors}");
            }
        }
    }
}
