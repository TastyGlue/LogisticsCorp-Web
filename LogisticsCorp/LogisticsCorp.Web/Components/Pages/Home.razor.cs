namespace LogisticsCorp.Web.Components.Pages;

public partial class Home : ExtendedComponentBase
{
    protected override void OnInitialized()
    {
        PageStateService.SetPageInfo("Dashboard", "Welcome to LogisticsCorp");
    }
}
