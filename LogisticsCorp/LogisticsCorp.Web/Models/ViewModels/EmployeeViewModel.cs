namespace LogisticsCorp.Web.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Guid? OfficeId { get; set; }
        public string? OfficeName { get; set; }
        public string EmployeeType { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public decimal? Salary { get; set; }
        public bool IsActive { get; set; }
    }
}
