namespace LogisticsCorp.Web.Components.Pages;

public partial class Login : ExtendedComponentBase
{
    [Inject] protected IApiAuthService ApiAuthService { get; set; } = default!;

    protected LoginModel Model { get; set; } = new();

    public string ErrorMessage { get; set; } = string.Empty;

    protected async Task ValidSubmitHandler(EditContext context)
    {
        // TODO: Implement login logic
        ErrorMessage = string.Empty;

        LoaderService.ToggleLoading(true);
        await Task.Delay(3500);
        var result = await ApiAuthService.LoginWithCredentials(Model.Adapt<LoginCredentials>());
        LoaderService.ToggleLoading(false);

        if (result.Succeeded)
        {
            // Store tokens in local storage and go to Home page
        }
        else
        {
            ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during login.";
        }
    }
}
