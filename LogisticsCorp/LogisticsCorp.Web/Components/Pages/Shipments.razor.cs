using LogisticsCorp.Shared.Models.DTOs;
using LogisticsCorp.Web.Models.ViewModels;
using LogisticsCorp.Web.Services.ApiServices.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LogisticsCorp.Web.Components.Pages
{
    public partial class Shipments : ExtendedComponentBase
    {
        [Inject] protected IApiShipmentService ApiShipmentService { get; set; } = default!;


        public List<ShipmentDto> shipments;
        public string ErrorMessage { get; set; } = string.Empty;


        private bool IsSaving = false;
        protected override async Task OnInitializedAsync()
        {

            PageStateService.SetPageInfo("Shipments Report", "View shipments info.");
            // TODO: Implement login logic
            ErrorMessage = string.Empty;

            LoaderService.ToggleLoading(true);

            // var result = await ApiAuthService.LoginWithCredentials(Model.Adapt<LoginCredentials>());
            var result = await ApiShipmentService.GetAll();
            LoaderService.ToggleLoading(false);

            if (result.Succeeded)
            {
                shipments = result.Value.ToList();
                // Store tokens in local storage and go to Home page

            }
            else
            {
                ErrorMessage = result.Error?.Message ?? "An unexpected error occurred during login.";
            }
        }

    }
}
