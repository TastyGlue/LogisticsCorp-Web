namespace LogisticsCorp.Data.Models;

/// <summary>
/// Represents an employee of the logistics company
/// </summary>
public class Employee : Account
{
    public Guid? OfficeId { get; set; }

    [Required]
    public EmployeeType EmployeeType { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    public decimal? Salary { get; set; }

    // Navigation properties
    [ForeignKey(nameof(OfficeId))]
    public Office? Office { get; set; }

    public ICollection<Shipment> RegisteredShipments { get; set; } = [];
    public ICollection<Shipment> AssignedShipments { get; set; } = [];
    public ICollection<ShipmentHistory> ShipmentHistoryEntries { get; set; } = [];
}