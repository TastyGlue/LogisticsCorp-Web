namespace LogisticsCorp.Web.Components.Pages.Admin.ManageClients
{
    public partial class CreateClient : ExtendedComponentBase
    {
        [Inject] protected IApiClientService ApiClientService { get; set; } = default!;

        protected ClientViewModel ViewModel { get; set; } = new() { User = new() };

        protected override void OnInitialized()
        {
            PageStateService.SetPageInfo("Create Client", "Add a new client to the system");
        }

        protected async Task ValidSubmitHandler()
        {
            var dto = ViewModel.Adapt<ClientDto>();
            var result = await ApiClientService.Create(dto);

            if (result.Succeeded)
            {
                Notify("Client created successfully.", Severity.Success);
                NavigationManager.NavigateTo("/manage-clients");
            }
            else
            {
                Notify(result.Error?.Message ?? "Failed to create client.", Severity.Error);
            }
        }
    }
}
