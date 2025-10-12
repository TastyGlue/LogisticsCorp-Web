namespace LogisticsCorp.Data.Models;

/// <summary>
/// Represents a shipment package being sent through the logistics company
/// </summary>
public class Shipment : IAuditedEntity
{
    public Guid Id { get; set; }

    [Required]
    public Guid SenderId { get; set; }

    [Required]
    public Guid RecipientId { get; set; }

    [Required]
    public Guid RegisteredByEmployeeId { get; set; }

    public Guid? CourierId { get; set; }

    public Guid? OriginOfficeId { get; set; }

    // Delivery details
    [Required]
    public DeliveryType DeliveryType { get; set; }

    public Guid? DestinationOfficeId { get; set; }

    [MaxLength(500)]
    public string? DeliveryAddress { get; set; }

    [MaxLength(100)]
    public string? DeliveryCity { get; set; }

    [MaxLength(20)]
    public string? DeliveryPostalCode { get; set; }

    // Shipment details
    [Required]
    public decimal Weight { get; set; }

    [MaxLength(1000)]
    public string Description { get; set; } = default!;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public ShipmentStatus Status { get; set; }

    // Tracking dates
    public DateTime RegisteredOn { get; set; }
    public DateTime? PickedUpOn { get; set; }
    public DateTime? DeliveredOn { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    // Navigation properties
    [ForeignKey(nameof(SenderId))]
    public Client Sender { get; set; } = default!;

    [ForeignKey(nameof(RecipientId))]
    public Client Recipient { get; set; } = default!;

    [ForeignKey(nameof(RegisteredByEmployeeId))]
    public Employee RegisteredByEmployee { get; set; } = default!;

    [ForeignKey(nameof(CourierId))]
    public Employee? Courier { get; set; }

    [ForeignKey(nameof(OriginOfficeId))]
    public Office? OriginOffice { get; set; }

    [ForeignKey(nameof(DestinationOfficeId))]
    public Office? DestinationOffice { get; set; }

    public ICollection<ShipmentHistory> History { get; set; } = [];
}