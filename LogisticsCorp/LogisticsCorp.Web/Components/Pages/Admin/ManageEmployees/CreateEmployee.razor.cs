namespace LogisticsCorp.Web.Components.Pages.Admin.ManageEmployees
{
    public partial class CreateEmployee : ExtendedComponentBase
    {
        [Inject] protected IApiEmployeeService ApiEmployeeService { get; set; } = default!;

        protected EmployeeViewModel ViewModel { get; set; } = new()
        {
            User = new(),
            HireDate = DateTime.UtcNow
        };

        protected override void OnInitialized()
        {
            PageStateService.SetPageInfo("Create Employee", "Add a new employee to the system");
        }

        protected async Task ValidSubmitHandler()
        {
            var dto = ViewModel.Adapt<EmployeeDto>();
            dto.Office = null;
            var result = await ApiEmployeeService.Create(dto);

            if (result.Succeeded)
            {
                Notify("Employee created successfully.", Severity.Success);
                NavigationManager.NavigateTo("/manage-employees");
            }
            else
            {
                Notify(result.Error?.Message ?? "Failed to create employee.", Severity.Error);
            }
        }
    }
}
