namespace LogisticsCorp.Shared.Models.DTOs;

public class EmployeeDto : AccountDto
{
    public Guid? OfficeId { get; set; }
    public EmployeeType EmployeeType { get; set; }
    public DateTime HireDate { get; set; }
    public decimal? Salary { get; set; }

    public OfficeDto? Office { get; set; } = default!;
}
