namespace LogisticsCorp.Web.Components.Pages
{
    public partial class UserShipments : ExtendedComponentBase
    {
        [Inject] protected IApiUserShipmentService ApiUserShipmentService { get; set; } = default!;

        protected List<ShipmentDto> Shipments { get; set; } = [];


        private bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            PageStateService.SetPageInfo("Your shipping", "View all things you've sent or received.");

            var accountId = UserStateContainer.AccountId;

            var result = await ApiUserShipmentService.GetAll(accountId);

            if (result.Succeeded)
            {
                Shipments = result.Value.ToList();
            }
            else
            {
                Notify(
                    result.Error?.Message ?? "An unexpected error occurred during login.",
                    Severity.Error
                );
            }

            _isLoading = false;
        }
    }
}
