namespace LogisticsCorp.Shared.Models.DTOs;

public class UserDto
{
    public string FullName { get; set; } = default!;

    public bool IsActive { get; set; }

    public Guid? AccountId { get; set; }

    public AccountDto? Account { get; set; } 

    public ICollection<RoleDto> Roles { get; set; } = [];
}
