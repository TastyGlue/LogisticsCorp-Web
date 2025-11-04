namespace LogisticsCorp.Web.Models.ViewModels
{
    public class OfficeViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public int EmployeesCount { get; set; }
        public int ShipmentsFromCount { get; set; }
        public int ShipmentsToCount { get; set; }
    }
}
