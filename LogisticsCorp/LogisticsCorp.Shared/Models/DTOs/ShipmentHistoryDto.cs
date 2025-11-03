namespace LogisticsCorp.Shared.Models.DTOs;

public class ShipmentHistoryDto
{
    public Guid Id { get; set; }
    public Guid ShipmentId { get; set; }
    public Guid? EmployeeId { get; set; }
    public ShipmentStatus Status { get; set; }
    public string? Notes { get; set; }
    public string? Location { get; set; }
    public DateTime CreatedOn { get; set; }

    public ShipmentDto? Shipment { get; set; } = default!;
    public EmployeeDto? Employee { get; set; } = default!;
}
