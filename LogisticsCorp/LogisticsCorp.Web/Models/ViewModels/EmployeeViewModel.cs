namespace LogisticsCorp.Web.Models.ViewModels
{
    public class EmployeeViewModel : AccountViewModel
    {
        public Guid? OfficeId { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }
        public OfficeViewModel? Office { get; set; } = default!;
        public string? OfficeName => Office?.Name ?? string.Empty;
    }
}
