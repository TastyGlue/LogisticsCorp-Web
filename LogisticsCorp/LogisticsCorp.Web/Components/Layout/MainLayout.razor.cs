namespace LogisticsCorp.Web.Components.Layout;

public partial class MainLayout : LayoutComponentBase, IDisposable
{
    [Inject]
    private PageStateService PageStateService { get; set; } = default!;

    private bool isDrawerOpen = true;
    private bool IsLoading { get; set; } = false;

    protected override void OnInitialized()
    {
        PageStateService.OnChange += HandlePageStateChanged;
    }

    private void HandlePageStateChanged()
    {
        StateHasChanged();
    }

    private void ToggleDrawer()
    {
        isDrawerOpen = !isDrawerOpen;
    }

    public void Dispose()
    {
        PageStateService.OnChange -= HandlePageStateChanged;
    }
}
