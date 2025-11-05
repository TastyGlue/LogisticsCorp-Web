using LogisticsCorp.Web.Services.ApiServices.Interfaces;
using static System.Net.WebRequestMethods;

namespace LogisticsCorp.Web.Components.Pages
{
    public partial class Contacts : ExtendedComponentBase
    {
        [Inject] protected IApiCompanyInfo ApiCompanyInfo { get; set; } = default!;

        protected CompanyInfoDTO Company { get; set; } = new();

        public string ErrorMessage { get; set; } = string.Empty;

        private List<(string Day, string Hours)> ScheduleList = new();
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
                if (Company != null)
                {
                    ScheduleList = new List<(string, string)>
            {
                ("Monday", Company.MondaySchedule),
                ("Tuesday", Company.TuesdaySchedule),
                ("Wednesday", Company.WednesdaySchedule),
                ("Thursday", Company.ThursdaySchedule),
                ("Friday", Company.FridaySchedule),
                ("Saturday", Company.SaturdaySchedule),
                ("Sunday", Company.SundaySchedule)
            };
                }
                StateHasChanged();
            }
            else
            {
                ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during login.";
            }
        }       
    }
}
