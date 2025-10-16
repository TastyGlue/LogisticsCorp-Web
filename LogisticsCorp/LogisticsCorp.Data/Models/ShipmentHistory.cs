namespace LogisticsCorp.Data.Models;

/// <summary>
/// Represents a history entry tracking status changes of a shipment
/// </summary>
public class ShipmentHistory
{
    public Guid Id { get; set; }

    [Required]
    public Guid ShipmentId { get; set; }

    public Guid? EmployeeId { get; set; }

    [Required]
    public ShipmentStatus Status { get; set; }

    [MaxLength(1000)]
    public string? Notes { get; set; }

    [MaxLength(500)]
    public string? Location { get; set; }

    public DateTime CreatedOn { get; set; }

    // Navigation properties
    [ForeignKey(nameof(ShipmentId))]
    public Shipment Shipment { get; set; } = default!;

    [ForeignKey(nameof(EmployeeId))]
    public Employee? Employee { get; set; }
}