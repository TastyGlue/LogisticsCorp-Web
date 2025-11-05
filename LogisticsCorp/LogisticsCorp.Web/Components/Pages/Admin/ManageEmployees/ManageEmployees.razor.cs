namespace LogisticsCorp.Web.Components.Pages.Admin.ManageEmployees
{
    public partial class ManageEmployees : ExtendedComponentBase
    {
        [Inject] protected IApiEmployeeService ApiEmployeeService { get; set; } = default!;

        protected List<EmployeeViewModel> _employees = new();
        protected EmployeeViewModel? _selectedEmployee;
        protected string _searchString = string.Empty;
        protected bool _isLoading = true;

        protected override async Task OnInitializedAsync()
        {
            PageTitle = "Manage Employees";
            await LoadEmployeesAsync();
        }

        private async Task LoadEmployeesAsync()
        {
            _isLoading = true;
            var result = await ApiEmployeeService.GetAll();
            if (result.Succeeded && result.Value is not null)
            {
                // Adapt DTOs into ViewModels
                _employees = result.Value.Adapt<List<EmployeeViewModel>>();
            }
            else
            {
                Notify(result.Error?.Message ?? "Failed to load employees.", Severity.Error);
                NavigationManager.NavigateTo("/");
            }
            _isLoading = false;
        }

        protected void CreateEmployee()
            => NavigationManager.NavigateTo("/manage-employees/create");

        protected void EditEmployee()
        {
            // Placeholder for future Edit form navigation
        }

        private bool QuickFilter(EmployeeViewModel employee)
        {
            if (string.IsNullOrWhiteSpace(_searchString))
                return true;

            return (employee.User.FullName?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false)
                || (employee.User.Email?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) ?? false);
        }
    }
}
