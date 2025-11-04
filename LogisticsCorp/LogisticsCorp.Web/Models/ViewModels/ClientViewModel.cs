namespace LogisticsCorp.Web.Models.ViewModels
{
    public class ClientViewModel : AccountViewModel
    {
        public Guid AccountId { get; set; }
        public AccountViewModel? Account { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        public int SentShipmentsCount { get; set; }
        public int ReceivedShipmentsCount { get; set; }

        // Navigation collections
        public ICollection<ShipmentViewModel> SentShipments { get; set; } = [];
        public ICollection<ShipmentViewModel> ReceivedShipments { get; set; } = [];

        // Computed summary properties
        public int SentCount => SentShipments?.Count ?? 0;
        public int ReceivedCount => ReceivedShipments?.Count ?? 0;

        // Equality logic for grids/forms
        public bool Equals(ClientViewModel? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id;
        }

        public override bool Equals(object? obj) => obj is ClientViewModel client && Equals(client);
        public override int GetHashCode() => Id.GetHashCode();
    }
}
