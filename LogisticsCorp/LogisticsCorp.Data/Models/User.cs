namespace LogisticsCorp.Data.Models;

public class User : IdentityUser<Guid>
{
    public string FullName { get; set; } = default!;

    public string? Address { get; set; }

    public bool IsActive { get; set; }

    public ICollection<IdentityRole<Guid>> Roles { get; set; } = [];
}
