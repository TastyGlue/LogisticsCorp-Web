namespace LogisticsCorp.Data.Models;

[Index(nameof(AccountId), IsUnique = true)]
public class User : IdentityUser<Guid>, IAuditedEntity
{
    public string FullName { get; set; } = default!;

    public bool IsActive { get; set; }

    public Guid? AccountId { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    // Navigation properties
    [ForeignKey(nameof(AccountId))]
    public Account? Account { get; set; }

    public ICollection<IdentityRole<Guid>> Roles { get; set; } = [];
}
