namespace LogisticsCorp.Data.Models;

/// <summary>
/// Represents pricing rules for calculating shipment costs
/// </summary>
public class PricingRule : IAuditedEntity
{
    public Guid Id { get; set; }

    [Required]
    public DeliveryType DeliveryType { get; set; }

    [Required]
    public decimal MinWeight { get; set; }

    [Required]
    public decimal MaxWeight { get; set; }

    [Required]
    public decimal PricePerKg { get; set; }

    [Required]
    public decimal BaseFee { get; set; }

    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; }
    public DateTime? ModifiedOn { get; set; }
}