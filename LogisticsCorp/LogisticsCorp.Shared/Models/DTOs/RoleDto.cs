namespace LogisticsCorp.Shared.Models.DTOs
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string NormalizedName { get; set; } = default!;
    }
}
