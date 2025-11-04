using LogisticsCorp.Shared.Models.DTOs;

namespace LogisticsCorp.Web.Components.Pages
{
    public partial class CompanyInfo : ExtendedComponentBase
    {
        [Inject] protected IApiCompanyInfo ApiCompanyInfo { get; set; } = default!;

        protected CompanyInfoDTO Model { get; set; } = new();

        public string ErrorMessage { get; set; } = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            // TODO: Implement login logic
            ErrorMessage = string.Empty;

            LoaderService.ToggleLoading(true);
           
            // var result = await ApiAuthService.LoginWithCredentials(Model.Adapt<LoginCredentials>());
            var result = await ApiCompanyInfo.Get();
            LoaderService.ToggleLoading(false);

            if (result.Succeeded)
            {
                // Store tokens in local storage and go to Home page
                Model = result.Value;
            }
            else
            {
                ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during login.";
            }
        }
    }
}
