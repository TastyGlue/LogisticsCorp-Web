namespace LogisticsCorp.Web.Models.ViewModels
{
    public class ShipmentViewModel
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }
        public string? SenderName { get; set; }

        public Guid RecipientId { get; set; }
        public string? RecipientName { get; set; }

        public Guid RegisteredByEmployeeId { get; set; }
        public string? RegisteredByEmployeeName { get; set; }

        public Guid? CourierId { get; set; }
        public string? CourierName { get; set; }

        public Guid? OriginOfficeId { get; set; }
        public string? OriginOfficeName { get; set; }

        public Guid? DestinationOfficeId { get; set; }
        public string? DestinationOfficeName { get; set; }

        public string DeliveryType { get; set; } = string.Empty;

        public string? DeliveryAddress { get; set; }
        public string? DeliveryCity { get; set; }
        public string? DeliveryPostalCode { get; set; }

        public decimal Weight { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;

        public DateTime RegisteredOn { get; set; }
        public DateTime? PickedUpOn { get; set; }
        public DateTime? DeliveredOn { get; set; }
    }
}
