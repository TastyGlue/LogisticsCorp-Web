using LogisticsCorp.Web.Models.ViewModels;

namespace LogisticsCorp.Web.Components.Pages.Admin.ManageShipments
{
    public partial class ManageShipments : ExtendedComponentBase
    {
        [Inject] protected IApiShipmentService ApiShipmentService { get; set; } = default!;

        protected List<ShipmentViewModel> _shipments = new();
        protected ShipmentViewModel? _selectedShipment;
        protected string _searchString = string.Empty;
        protected bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            PageTitle = "Manage Shipments";
            await LoadShipmentsAsync();
        }

        private async Task LoadShipmentsAsync()
        {
            _isLoading = true;
            var result = await ApiShipmentService.GetAll();
            if (result.Succeeded && result.Value is not null)
            {
                _shipments = result.Value.Adapt<List<ShipmentViewModel>>();
            }
            else
            {
                Notify(result.Error?.Message ?? "Failed to load shipments.", Severity.Error);
                NavigationManager.NavigateTo("/");
            }
            _isLoading = false;
        }

        protected void CreateShipment() { }
        protected void EditShipment() { }

        private bool QuickFilter(ShipmentViewModel shipment)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            return (shipment.Sender?.User.FullName.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (shipment.Recipient?.User.FullName.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}
