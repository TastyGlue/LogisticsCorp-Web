using LogisticsCorp.Web.Models.ViewModels;
using Microsoft.AspNetCore.Components;

namespace LogisticsCorp.Web.Components.Pages.Admin.ManageOffices
{
    public partial class Form : ExtendedComponentBase
    {
        [Parameter] public bool IsCreate { get; init; } = true;
        [Parameter] public OfficeViewModel ViewModel { get; set; } = new();
        [Parameter] public EventCallback OnValidSubmit { get; set; }

        protected async Task ValidSubmitHandler(EditContext context)
        {
            await OnValidSubmit.InvokeAsync();
        }

        protected void CancelHandler()
            => NavigationManager.NavigateTo("/manage-offices");
    }
}
