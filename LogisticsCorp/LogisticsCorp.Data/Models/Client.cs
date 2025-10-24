namespace LogisticsCorp.Data.Models;

/// <summary>
/// Represents a customer of the logistics company
/// </summary>
public class Client : Account
{
    [MaxLength(500)]
    public string Address { get; set; } = default!;

    [MaxLength(100)]
    public string City { get; set; } = default!;

    [MaxLength(20)]
    public string PostalCode { get; set; } = default!;

    // Navigation properties
    public ICollection<Shipment> SentShipments { get; set; } = [];
    public ICollection<Shipment> ReceivedShipments { get; set; } = [];
}