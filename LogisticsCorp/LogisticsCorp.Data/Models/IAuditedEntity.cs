namespace LogisticsCorp.Data.Models;

/// <summary>
/// Interface for entities that track creation and modification timestamps
/// </summary>
public interface IAuditedEntity
{
    DateTime CreatedOn { get; set; }

    DateTime? ModifiedOn { get; set; }
}
