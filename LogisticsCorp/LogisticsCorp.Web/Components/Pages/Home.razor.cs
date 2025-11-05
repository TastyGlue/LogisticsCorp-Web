namespace LogisticsCorp.Web.Components.Pages;

public partial class Home : ExtendedComponentBase
{
    private bool _drawerOpen = false;

    private void ToggleDrawer()
    {
        _drawerOpen = !_drawerOpen;
    }
}
