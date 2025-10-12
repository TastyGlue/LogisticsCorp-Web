namespace LogisticsCorp.Data.Models;

/// <summary>
/// Represents an employee of the logistics company
/// </summary>
public class Employee : IAuditedEntity
{
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public Guid? OfficeId { get; set; }

    [Required]
    public EmployeeType EmployeeType { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    public bool IsActive { get; set; }

    public decimal? Salary { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = default!;

    [ForeignKey(nameof(OfficeId))]
    public Office? Office { get; set; }

    public ICollection<Shipment> RegisteredShipments { get; set; } = [];
    public ICollection<Shipment> DeliveredShipments { get; set; } = [];
    public ICollection<ShipmentHistory> ShipmentHistoryEntries { get; set; } = [];
}