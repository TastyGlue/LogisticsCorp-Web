using LogisticsCorp.Web.Models.ViewModels;

namespace LogisticsCorp.Web.Components.Pages.Admin.ManageClients
{
    public partial class ManageClients : ExtendedComponentBase
    {
        [Inject] protected IApiClientService ApiClientService { get; set; } = default!;

        protected List<ClientViewModel> _clients = new();
        protected ClientViewModel? _selectedClient;
        protected string _searchString = string.Empty;
        protected bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            PageTitle = "Manage Clients";
            await LoadClientsAsync();
        }

        private async Task LoadClientsAsync()
        {
            _isLoading = true;
            var result = await ApiClientService.GetAll();
            if (result.Succeeded && result.Value is not null)
            {
                _clients = result.Value.Adapt<List<ClientViewModel>>();
            }
            else
            {
                Notify(result.Error?.Message ?? "Failed to load clients.", Severity.Error);
                NavigationManager.NavigateTo("/");
            }
            _isLoading = false;
        }

        protected void CreateClient()
            => NavigationManager.NavigateTo("/manage-clients/create"); 
        protected void EditClient() { }

        private bool QuickFilter(ClientViewModel client)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            return (client.User.FullName?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (client.User.Email?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (client.City?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (client.PostalCode?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}
