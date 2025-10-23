namespace LogisticsCorp.Data.Models;

[Index(nameof(UserId), IsUnique = true)]
public class Account : IAuditedEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    // Navigation properties
    public User User { get; set; } = default!;
}
