namespace LogisticsCorp.Data.Models;

/// <summary>
/// Represents a company office location
/// </summary>
public class Office : IAuditedEntity
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = default!;

    [Required]
    [MaxLength(500)]
    public string Address { get; set; } = default!;

    [Required]
    [MaxLength(100)]
    public string City { get; set; } = default!;

    [MaxLength(20)]
    public string PostalCode { get; set; } = default!;

    [MaxLength(20)]
    public string PhoneNumber { get; set; } = default!;

    [MaxLength(100)]
    public string Email { get; set; } = default!;

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }

    // Navigation properties
    public ICollection<Employee> Employees { get; set; } = [];
    public ICollection<Shipment> ShipmentsFromThisOffice { get; set; } = [];
    public ICollection<Shipment> ShipmentsToThisOffice { get; set; } = [];
}