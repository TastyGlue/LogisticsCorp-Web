namespace LogisticsCorp.Shared.Models.DTOs;

public class ClientDto : AccountDto
{
    public string Address { get; set; } = default!;
    public string City { get; set; } = default!;
    public string PostalCode { get; set; } = default!;

    public ICollection<ShipmentDto>? SentShipments { get; set; } = default!;
    public ICollection<ShipmentDto>? ReceivedShipments { get; set; } = default!;
}
