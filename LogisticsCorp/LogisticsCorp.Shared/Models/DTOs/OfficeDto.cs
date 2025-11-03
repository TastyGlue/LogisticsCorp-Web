namespace LogisticsCorp.Shared.Models.DTOs;

public class OfficeDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Address { get; set; } = default!;
    public string City { get; set; } = default!;
    public string PostalCode { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Email { get; set; } = default!;
    public bool IsActive { get; set; }

    public ICollection<EmployeeDto>? Employees { get; set; } = default!;
    public ICollection<ShipmentDto>? ShipmentsFromThisOffice { get; set; } = default!;
    public ICollection<ShipmentDto>? ShipmentsToThisOffice { get; set; } = default!;
}
