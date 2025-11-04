namespace LogisticsCorp.Web.Models.ViewModels
{
    public class ClientViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public int SentShipmentsCount { get; set; }
        public int ReceivedShipmentsCount { get; set; }
    }
}
