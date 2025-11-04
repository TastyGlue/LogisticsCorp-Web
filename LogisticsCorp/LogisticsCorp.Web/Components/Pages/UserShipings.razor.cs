using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Components.Pages
{
    public partial class UserShipings : ExtendedComponentBase
    {
        [Inject] protected IApiUserShipmentService ApiUserShipmentService { get; set; } = default!;

        protected List<ShipmentDto> userShipments { get; set; } = new();

        public string ErrorMessage { get; set; } = string.Empty;


        private bool IsSaving = false;

        private bool noShippingsFound;

        protected override async Task OnInitializedAsync()
        {

            PageStateService.SetPageInfo("Your shipping", "View all things you've sent or received.");
            // TODO: Implement login logic
            ErrorMessage = string.Empty;

            LoaderService.ToggleLoading(true);

            var accountId = UserStateContainer.AccountId;

            var result = await ApiUserShipmentService.GetAll(accountId);

            LoaderService.ToggleLoading(false);

            if (result.Succeeded)
            {
                // Store tokens in local storage and go to Home page
                userShipments = result.Value.ToList();
                if(userShipments == null || userShipments.Count == 0)
                {
                    noShippingsFound = true;
                }
            }
            else
            {
                ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during login.";
            }
        }
    }
}
