namespace LogisticsCorp.Shared.Models.DTOs;

public class ShipmentDto
{
    public Guid Id { get; set; }
    public Guid SenderId { get; set; }
    public Guid RecipientId { get; set; }
    public Guid RegisteredByEmployeeId { get; set; }
    public Guid? CourierId { get; set; }
    public Guid? OriginOfficeId { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public Guid? DestinationOfficeId { get; set; }
    public string? DeliveryAddress { get; set; }
    public string? DeliveryCity { get; set; }
    public string? DeliveryPostalCode { get; set; }
    public decimal Weight { get; set; }
    public string Description { get; set; } = default!;
    public decimal Price { get; set; }
    public ShipmentStatus Status { get; set; }
    public DateTime RegisteredOn { get; set; }
    public DateTime? PickedUpOn { get; set; }
    public DateTime? DeliveredOn { get; set; }

    public ClientDto? Sender { get; set; } = default!;
    public ClientDto? Recipient { get; set; } = default!;
    public EmployeeDto? RegisteredByEmployee { get; set; } = default!;
    public EmployeeDto? Courier { get; set; } = default!;
    public OfficeDto? OriginOffice { get; set; } = default!;
    public OfficeDto? DestinationOffice { get; set; } = default!;
    public ICollection<ShipmentHistoryDto>? History { get; set; } = default!;
}
