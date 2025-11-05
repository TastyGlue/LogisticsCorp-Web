using LogisticsCorp.Shared.Models.DTOs;
using LogisticsCorp.Web.Models.ViewModels;
using Mapster;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LogisticsCorp.Web.Components.Pages.Admin.ManageOffices
{
    public partial class CreateOffice : ExtendedComponentBase
    {
        [Inject] protected IApiOfficeService ApiOfficeService { get; set; } = default!;
        [Inject] protected PageStateService PageStateService { get; set; } = default!;

        protected OfficeViewModel ViewModel { get; set; } = new();

        protected override void OnInitialized()
        {
            PageStateService.SetPageInfo("Create Office", "Add a new office to the system");
        }

        protected async Task ValidSubmitHandler()
        {
            var dto = ViewModel.Adapt<OfficeDto>();
            var result = await ApiOfficeService.Create(dto);

            if (result.Succeeded)
            {
                Notify("Office created successfully.", Severity.Success);
                NavigationManager.NavigateTo("/manage-offices");
            }
            else
            {
                Notify(result.Error?.Message ?? "Failed to create office.", Severity.Error);
            }
        }
    }
}
