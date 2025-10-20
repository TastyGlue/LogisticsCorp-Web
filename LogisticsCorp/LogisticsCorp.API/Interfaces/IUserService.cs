namespace LogisticsCorp.API.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Assigns a user to a specified role, with an option to overwrite any existing roles.
    /// </summary>
    /// <remarks>This method interacts with the underlying user management system to assign roles to users.
    /// If <paramref name="overwriteExisting"/> is set to <see langword="true"/>, any roles currently assigned  to the
    /// user will be removed before the new role is assigned. If <paramref name="overwriteExisting"/> is  <see
    /// langword="false"/> and the user already has a role, the operation will fail.</remarks>
    /// <param name="userId">The unique identifier of the user to assign to the role.</param>
    /// <param name="roleName">The name of the role to assign to the user.</param>
    /// <param name="overwriteExisting">A boolean value indicating whether to remove the user's existing roles before assigning the new role. If <see
    /// langword="true"/>, any existing roles will be removed before the new role is assigned. If <see
    /// langword="false"/>, the operation will fail if the user already has a role assigned.</param>
    /// <returns>A <see cref="CustomResult"/> indicating the outcome of the operation.  If successful, the result will indicate
    /// success. If the operation fails, the result will contain error details.</returns>
    Task<CustomResult> AddUserToRole(Guid userId, string roleName, bool overwriteExisting = false);
}
