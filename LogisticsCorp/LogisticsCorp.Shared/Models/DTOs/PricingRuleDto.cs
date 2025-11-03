namespace LogisticsCorp.Shared.Models.DTOs;

public class PricingRuleDto
{
    public Guid Id { get; set; }
    public DeliveryType DeliveryType { get; set; }
    public decimal MinWeight { get; set; }
    public decimal MaxWeight { get; set; }
    public decimal PricePerKg { get; set; }
    public decimal BaseFee { get; set; }
    public bool IsActive { get; set; }
}
