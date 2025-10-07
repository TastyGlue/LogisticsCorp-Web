namespace LogisticsCorp.Web.Services;

/// <summary>
/// Represents a container for storing and managing user-related state information.
/// </summary>
/// <remarks>This class provides properties to hold user-specific details such as identifiers, contact
/// information and roles. It is designed to encapsulate the state of a user within an application context.</remarks>
public class UserStateContainer
{
    public bool IsPopulated { get; set; }

    public Guid Id { get; set; }

    public string UserName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string? PhoneNumber { get; set; }

    public string FullName { get; set; } = default!;

    public string[] Roles { get; set; } = [];
}
