namespace LogisticsCorp.API.Services;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<CustomResult> AddUserToRole(Guid userId, string roleName, bool overwriteExisting = false)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        // Check if User exists
        if (user is null)
            return new (new ErrorResult("User not found", ErrorCodes.ENTITY_NOT_FOUND));

        // Get User Roles
        var roles = await _userManager.GetRolesAsync(user);

        // Check existing roles
        if (!overwriteExisting && roles.Count > 0)
            return new (new ErrorResult(
                $"User '{user.UserName}' already has a role assigned",
                ErrorCodes.USER_UPDATE_FAILED
            ));

        // Overwrite existing roles if specified
        if (overwriteExisting && roles.Count > 0)
        {
            var removeResult = await _userManager.RemoveFromRolesAsync(user, roles);
            if (!removeResult.Succeeded)
                return new (new ErrorResult(
                    $"Removing existing roles from user '{user.UserName}' failed",
                    ErrorCodes.USER_UPDATE_FAILED,
                    removeResult.Errors.Select(x => x.Description).ToList()
                ));
        }

        var addResult = await _userManager.AddToRoleAsync(user, roleName);

        if (addResult.Succeeded)
            return new();
        else
            return new(new ErrorResult(
                $"Adding user '{user.UserName}' to role '{roleName}' failed",
                ErrorCodes.USER_UPDATE_FAILED,
                addResult.Errors.Select(x => x.Description).ToList()
            ));
    }
}
