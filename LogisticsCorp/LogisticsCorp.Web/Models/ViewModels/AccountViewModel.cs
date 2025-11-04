using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Models.ViewModels
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        // Navigation properties
        public UserViewModel User { get; set; } = default!;
    }
}
