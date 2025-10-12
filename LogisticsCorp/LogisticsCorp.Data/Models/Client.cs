namespace LogisticsCorp.Data.Models;

/// <summary>
/// Represents a customer of the logistics company
/// </summary>
public class Client : IAuditedEntity
{
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; }

    [MaxLength(500)]
    public string Address { get; set; } = default!;

    [MaxLength(100)]
    public string City { get; set; } = default!;

    [MaxLength(20)]
    public string PostalCode { get; set; } = default!;

    public bool IsActive { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public User User { get; set; } = default!;

    public ICollection<Shipment> SentShipments { get; set; } = [];
    public ICollection<Shipment> ReceivedShipments { get; set; } = [];
}