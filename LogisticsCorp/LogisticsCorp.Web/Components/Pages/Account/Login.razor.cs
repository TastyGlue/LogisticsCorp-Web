namespace LogisticsCorp.Web.Components.Pages.Account;

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
        await Task.Delay(360 * 1000);
        var result = await ApiAuthService.LoginWithCredentials(Model.Adapt<LoginCredentials>());

        LoaderService.ToggleLoading(false);

        if (result.Succeeded)
        {
            // Store tokens in local storage and go to Home page
            var tokens = result.Value!;

            await LocalStorage.SetAsync(Constants.ACCESS_TOKEN_KEY, tokens.AccessToken);
            await LocalStorage.SetAsync(Constants.REFRESH_TOKEN_KEY, tokens.RefreshToken);

            NavigationManager.NavigateTo("/", true);
        }
        else
        {
            ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during login.";
        }
    }
}
