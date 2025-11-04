using LogisticsCorp.Shared.Models.DTOs;
using LogisticsCorp.Web.Models.ViewModels;
using LogisticsCorp.Web.Services.ApiServices.Interfaces;
using Microsoft.AspNetCore.Components;

namespace LogisticsCorp.Web.Components.Pages.Admin.ManageClients
{
    public partial class CreateClient : ExtendedComponentBase
    {
        [Inject] protected IApiClientService ApiClientService { get; set; } = default!;

        protected ClientViewModel ViewModel { get; set; } = new();

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
