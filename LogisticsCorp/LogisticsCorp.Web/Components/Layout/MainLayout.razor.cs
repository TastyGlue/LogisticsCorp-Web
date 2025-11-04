using System.Security.Claims;

namespace LogisticsCorp.Web.Components.Layout;

public partial class MainLayout : LayoutComponentBase, IDisposable
{
    [CascadingParameter] private Task<AuthenticationState> authenticationStateTask { get; set; } = default!;

    [Inject] private NavigationManager NavigationManager { get; set; } = default!;

    [Inject] public UserStateContainer UserStateContainer { get; set; } = default!;

    [Inject] private LoaderService LoaderService { get; set; } = default!;

    [Inject] private PageStateService PageStateService { get; set; } = default!;

    private ClaimsPrincipal User { get; set; } = default!;

    private bool isDrawerOpen = true;
    private bool IsLoading { get; set; } = false;

    protected override async Task OnInitializedAsync()
    {
        PageStateService.OnChange += HandlePageStateChanged;

        LoaderService.Register(state =>
        {
            InvokeAsync(() =>
            {
                IsLoading = state;
                StateHasChanged();
            });
        });

        User = (await authenticationStateTask).User;

        if (!(User.Identity?.IsAuthenticated ?? false))
        {
            NavigationManager.NavigateTo("/account/login");
            return;
        }

        CreateUserStateContainer();
    }

    private void CreateUserStateContainer()
    {
        if (UserStateContainer.Id == Guid.Empty)
        {
            UserStateContainer.Id = new Guid(User.FindFirstValue(Claims.USER_ID)!);
        }

        if (string.IsNullOrWhiteSpace(UserStateContainer.UserName))
        {
            UserStateContainer.UserName = User.FindFirstValue(Claims.USERNAME)!;
        }

        if (string.IsNullOrWhiteSpace(UserStateContainer.Email))
        {
            UserStateContainer.Email = User.FindFirstValue(Claims.EMAIL)!;
        }

        if (string.IsNullOrWhiteSpace(UserStateContainer.FullName))
        {
            UserStateContainer.FullName = User.FindFirstValue(Claims.FULL_NAME)!;
        }

        if (string.IsNullOrWhiteSpace(UserStateContainer.Role))
        {
            UserStateContainer.Role = User.FindFirstValue(Claims.ROLE)!;
        }

        if (UserStateContainer.AccountId == Guid.Empty)
        {
            UserStateContainer.AccountId = new Guid(User.FindFirstValue(Claims.ACCOUNT_ID)!);
        }

        if (UserStateContainer.EmployeeType is null)
        {
            var employeeTypeClaim = User.FindFirstValue(Claims.EMPLOYEE_TYPE);
            EmployeeType? employeeType = employeeTypeClaim is not null
                ? Enum.Parse<EmployeeType>(employeeTypeClaim, true)
                : null;
            UserStateContainer.EmployeeType = employeeType;
        }

        UserStateContainer.IsPopulated = true;
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
