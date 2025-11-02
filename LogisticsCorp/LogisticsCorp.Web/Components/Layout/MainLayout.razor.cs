namespace LogisticsCorp.Web.Components.Layout;

public partial class MainLayout : LayoutComponentBase
{
    private bool isDrawerOpen = true;
    private bool IsLoading { get; set; } = false;

    // Page title and subtitle properties (can be set from individual pages)
    protected string PageTitle { get; set; } = "Dashboard";
    protected string PageSubtitle { get; set; } = "Welcome to LogisticsCorp";

    private void ToggleDrawer()
    {
        isDrawerOpen = !isDrawerOpen;
    }
}
