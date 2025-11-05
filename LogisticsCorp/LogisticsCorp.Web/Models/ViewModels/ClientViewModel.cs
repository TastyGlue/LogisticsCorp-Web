namespace LogisticsCorp.Web.Models.ViewModels
{
    public class ClientViewModel : AccountViewModel
    {
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }

        // Navigation collections
        public ICollection<ShipmentViewModel> SentShipments { get; set; } = [];
        public ICollection<ShipmentViewModel> ReceivedShipments { get; set; } = [];
    }
}
