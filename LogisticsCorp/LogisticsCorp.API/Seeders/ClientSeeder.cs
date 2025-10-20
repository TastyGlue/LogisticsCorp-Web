namespace LogisticsCorp.API.Seeders;

public class ClientSeeder : IDataSeeder
{
    private readonly IUserService _userService;

    public ClientSeeder(IUserService userService)
    {
        _userService = userService;
    }

    public int Order => 6;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<Client>("Seeds/ClientSeedData.json");

        foreach (var client in data)
        {
            if (await context.Set<Client>().AnyAsync(c => c.Id == client.Id)) continue;

            // Assign user to CLIENT role first
            var result = await _userService.AddUserToRole(client.UserId, SeedConstants.ROLE_CLIENT_NAME, overwriteExisting: false);
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to assign {SeedConstants.ROLE_CLIENT_NAME} role to user '{client.UserId}': {result.Error?.Message}");
            }

            // Only add client to database if role assignment succeeded
            context.Set<Client>().Add(client);
        }

        await context.SaveChangesAsync();
    }
}
