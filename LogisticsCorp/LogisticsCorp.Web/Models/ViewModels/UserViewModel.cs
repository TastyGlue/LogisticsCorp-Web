namespace LogisticsCorp.Web.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string FullName { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string? PhoneNumber { get; set; }

        public bool IsActive { get; set; }

        public Guid? AccountId { get; set; }

        // Optional navigation to Account (useful for display but not for editing directly)
        public AccountViewModel? Account { get; set; }

        public ICollection<RoleViewModel>? Roles { get; set; } = [];
    }
}
