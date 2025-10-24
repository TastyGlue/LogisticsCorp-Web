namespace LogisticsCorp.Data.Models;

[Index(nameof(Token), IsUnique = true)]
public class RefreshToken
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid UserId { get; set; } = default!;

    [Required]
    public string Token { get; set; } = default!;

    [Required]
    public DateTime ExpireOn { get; set; }
}
