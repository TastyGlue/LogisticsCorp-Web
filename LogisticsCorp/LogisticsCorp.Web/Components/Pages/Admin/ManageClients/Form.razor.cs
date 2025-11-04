using LogisticsCorp.Web.Models.ViewModels;
using MudBlazor;

namespace LogisticsCorp.Web.Components.Pages.Admin.ManageClients;

public partial class Form : ExtendedComponentBase
{
    [Parameter] public bool IsCreate { get; init; } = true;
    [Parameter] public string PageTitle { get; set; } = default!;
    [Parameter] public ClientViewModel ViewModel { get; set; } = new();
    [Parameter] public EventCallback OnValidSubmit { get; set; }

    protected MudForm FormRef { get; set; } = default!;

    protected async Task SubmitHandler()
    {
        await FormRef.Validate();

        if (FormRef.IsValid)
            await OnValidSubmit.InvokeAsync();
    }

    protected void CancelHandler()
        => NavigationManager.NavigateTo("/manage-clients");
}
