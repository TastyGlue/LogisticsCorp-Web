namespace LogisticsCorp.Web.Models.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters")]
        public string FullName { get; set; } = default!;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = default!;

        public bool IsActive { get; set; }

        public Guid? AccountId { get; set; }

        // Optional navigation to Account (useful for display but not for editing directly)
        public AccountViewModel? Account { get; set; }

        public ICollection<RoleViewModel>? Roles { get; set; } = [];
    }
}
