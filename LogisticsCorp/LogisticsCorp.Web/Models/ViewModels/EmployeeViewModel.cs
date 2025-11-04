namespace LogisticsCorp.Web.Models.ViewModels
{
    public class EmployeeViewModel : AccountViewModel
    {
        public Guid Id { get; set; }
        public Guid? OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public string EmployeeType { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
