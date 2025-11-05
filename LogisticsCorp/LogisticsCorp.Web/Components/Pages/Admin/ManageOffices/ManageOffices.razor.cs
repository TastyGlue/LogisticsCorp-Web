using LogisticsCorp.Web.Models.ViewModels;

namespace LogisticsCorp.Web.Components.Pages.Admin.ManageOffices
{
    public partial class ManageOffices : ExtendedComponentBase
    {
        [Inject] protected IApiOfficeService ApiOfficeService { get; set; } = default!;

        protected List<OfficeViewModel> _offices = new();
        protected OfficeViewModel? _selectedOffice;
        protected string _searchString = string.Empty;
        protected bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            PageTitle = "Manage Offices";
            await LoadOfficesAsync();
        }

        private async Task LoadOfficesAsync()
        {
            _isLoading = true;
            var result = await ApiOfficeService.GetAll();
            if (result.Succeeded && result.Value is not null)
            {
                _offices = result.Value.Adapt<List<OfficeViewModel>>();
            }
            else
            {
                Notify(result.Error?.Message ?? "Failed to load offices.", Severity.Error);
                NavigationManager.NavigateTo("/");
            }
            _isLoading = false;
        }

        protected void CreateOffice()
            => NavigationManager.NavigateTo("/manage-offices/create");
        protected void EditOffice() { }

        private bool QuickFilter(OfficeViewModel office)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            return (office.Name?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (office.City?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (office.Address?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (office.Email?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (office.PhoneNumber?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}
