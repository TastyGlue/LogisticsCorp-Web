namespace LogisticsCorp.Data.Models;

[Index(nameof(EmployeeId), IsUnique = true)]
[Index(nameof(ClientId), IsUnique = true)]
public class User : IdentityUser<Guid>, IAuditedEntity
{
    public string FullName { get; set; } = default!;

    public bool IsActive { get; set; }

    public Guid? EmployeeId { get; set; }

    public Guid? ClientId { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    // Navigation properties
    public Employee? Employee { get; set; }

    public Client? Client { get; set; }

    public ICollection<IdentityRole<Guid>> Roles { get; set; } = [];
}
