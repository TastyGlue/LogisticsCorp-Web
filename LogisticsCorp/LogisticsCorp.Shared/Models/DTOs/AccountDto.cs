namespace LogisticsCorp.Shared.Models.DTOs;

public class AccountDto
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    // Navigation properties
    public UserDto User { get; set; } = default!;
}
