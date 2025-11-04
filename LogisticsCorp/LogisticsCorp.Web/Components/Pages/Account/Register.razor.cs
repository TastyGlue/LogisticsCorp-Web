namespace LogisticsCorp.Web.Components.Pages.Account;

public partial class Register : ExtendedComponentBase
{
    [Inject] protected IApiAuthService ApiAuthService { get; set; } = default!;

    protected RegisterViewModel Model { get; set; } = new();

    protected string ErrorMessage { get; set; } = string.Empty;

    protected async Task ValidSubmitHandler(EditContext context)
    {
        ErrorMessage = string.Empty;

        LoaderService.ToggleLoading(true);
        var result = await ApiAuthService.Register(Model.Adapt<RegisterDto>());
        LoaderService.ToggleLoading(false);

        if (result.Succeeded)
        {
            // Registration successful, navigate to login page
            Notify("Registration successful", Severity.Success);
            NavigationManager.NavigateTo("/account/login");
        }
        else
        {
            ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during registration.";
        }
    }
}
