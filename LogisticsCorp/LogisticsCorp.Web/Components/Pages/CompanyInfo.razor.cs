using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Components.Pages
{
    public partial class CompanyInfo : ExtendedComponentBase
    {
        [Inject] protected IApiCompanyInfo ApiCompanyInfo { get; set; } = default!;

        protected CompanyInfoDTO Company { get; set; } = new();

        public string ErrorMessage { get; set; } = string.Empty;

        
        private bool IsSaving = false;


        protected override async Task OnInitializedAsync()
        {

            PageStateService.SetPageInfo("Company Info", "View and edit company information.");
            // TODO: Implement login logic
            ErrorMessage = string.Empty;

            LoaderService.ToggleLoading(true);

            // var result = await ApiAuthService.LoginWithCredentials(Model.Adapt<LoginCredentials>());
            var result = await ApiCompanyInfo.Get();
            LoaderService.ToggleLoading(false);

            if (result.Succeeded)
            {
                // Store tokens in local storage and go to Home page
                Company = result.Value;
            }
            else
            {
                ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during login.";
            }
        }
        protected async Task ValidSubmitHandler(EditContext context)
        {
            // TODO: Implement login logic
            ErrorMessage = string.Empty;

            LoaderService.ToggleLoading(true);

            var result = await ApiCompanyInfo.Update(Company);

            LoaderService.ToggleLoading(false);

            if (result.Succeeded)
            {
                Notify("Company info updated successfully!", Severity.Success);




                NavigationManager.NavigateTo("/");
            }
            else
            {
                ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during login.";
            }
        }       
    }
}
