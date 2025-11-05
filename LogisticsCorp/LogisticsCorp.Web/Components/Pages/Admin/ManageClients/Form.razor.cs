namespace LogisticsCorp.Web.Components.Pages.Admin.ManageClients;

public partial class Form : ExtendedComponentBase
{
    [Parameter] public bool IsCreate { get; init; } = true;
    [Parameter] public ClientViewModel ViewModel { get; set; } = new();
    [Parameter] public EventCallback OnValidSubmit { get; set; }

    protected async Task ValidSubmitHandler(EditContext context)
    {
        await OnValidSubmit.InvokeAsync();
    }

    protected void CancelHandler()
        => NavigationManager.NavigateTo("/manage-clients");
}
