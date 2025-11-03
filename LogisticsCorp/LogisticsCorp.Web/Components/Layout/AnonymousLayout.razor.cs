
namespace LogisticsCorp.Web.Components.Layout;

public partial class AnonymousLayout : LayoutComponentBase
{
    [Inject] private LoaderService LoaderService { get; set; } = default!;

    private bool IsLoading { get; set; } = false;

    protected override void OnInitialized()
    {
        LoaderService.Register(state =>
        {
            InvokeAsync(() =>
            {
                IsLoading = state;
                StateHasChanged();
            });
        });
    }
}
