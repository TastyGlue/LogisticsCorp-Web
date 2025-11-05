namespace LogisticsCorp.Web.Components.Pages;

public partial class Dashboard : ExtendedComponentBase
{
    protected override void OnInitialized()
    {
        PageStateService.SetPageInfo("Dashboard", "Overview of logistics operations.");
    }
}
