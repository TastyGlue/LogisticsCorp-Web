using static MudBlazor.Defaults;

namespace LogisticsCorp.Web.Components.Pages.Admin.ManageEmployees;

public partial class Form : ExtendedComponentBase
{
    [Inject] protected IApiOfficeService ApiOfficeService { get; set; } = default!;

    [Parameter] public bool IsCreate { get; init; } = true;
    [Parameter] public EmployeeViewModel ViewModel { get; set; } = new();
    [Parameter] public EventCallback OnValidSubmit { get; set; }

    protected List<OfficeViewModel> _offices = new();

    protected override async Task OnInitializedAsync()
    {
        await LoadOfficesAsync();
    }

    private async Task LoadOfficesAsync()
    {
        var result = await ApiOfficeService.GetAll();
        if (result.Succeeded && result.Value is not null)
        {
            _offices = result.Value.Adapt<List<OfficeViewModel>>();
        }
        else
        {
            Notify(result.Error?.Message ?? "Failed to load offices.", Severity.Error);
        }
    }

    protected void SelectedOfficeChanged(OfficeViewModel? value)
    {
        ViewModel.Office = value;
        ViewModel.OfficeId = value?.Id ?? null;
    }

    protected async Task<IEnumerable<OfficeViewModel>> SearchOffices(string searchValue, CancellationToken token)
    {
        if (searchValue is null)
            return _offices;

        await Task.Yield();

        return _offices.Where(x => x.Name.Contains(searchValue, StringComparison.OrdinalIgnoreCase));
    }

    protected async Task ValidSubmitHandler(EditContext context)
    {
        ViewModel.Office = null;
        await OnValidSubmit.InvokeAsync();
    }

    protected void CancelHandler()
        => NavigationManager.NavigateTo("/manage-employees");
}
