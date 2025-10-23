namespace LogisticsCorp.API.Seeders;

public class ClientSeeder : IDataSeeder
{
    private readonly IUserService _userService;
    private readonly UserManager<User> _userManager;

    public ClientSeeder(IUserService userService, UserManager<User> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    public int Order => 5;

    public async Task Seed(DbContext context)
    {
        var data = ReadJsonDataFile<Client>("Seeds/ClientSeedData.json");

        foreach (var client in data)
        {
            if (await context.Set<Client>().AnyAsync(c => c.Id == client.Id)) continue;

            // Add client (which will also add the nested User via EF Core)
            client.User.SecurityStamp = Guid.NewGuid().ToString(); // Ensure unique SecurityStamp
            context.Set<Client>().Add(client);
            await context.SaveChangesAsync();

            // After successful creation, assign user to CLIENT role
            var roleResult = await _userService.AddUserToRole(client.UserId, SeedConstants.ROLE_CLIENT_NAME, overwriteExisting: false);
            if (!roleResult.Succeeded)
            {
                throw new Exception($"Failed to assign {SeedConstants.ROLE_CLIENT_NAME} role to user '{client.UserId}': {roleResult.Error?.Message}");
            }

            // Reset password to default
            var user = await _userManager.FindByIdAsync(client.UserId.ToString());
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
