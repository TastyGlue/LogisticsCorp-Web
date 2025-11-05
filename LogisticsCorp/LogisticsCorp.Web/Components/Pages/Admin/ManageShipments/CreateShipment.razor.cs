namespace LogisticsCorp.Web.Components.Pages.Admin.ManageShipments
{
    public partial class CreateShipment : ExtendedComponentBase
    {
        [Inject] private IApiShipmentService ApiShipmentService { get; set; } = default!;
        [Inject] private IApiClientService ApiClientService { get; set; } = default!;


        private ShipmentDto Shipment = new();

        private bool IsSaving = false;

        private List<ClientDto> clients = new();

        protected override async Task OnInitializedAsync()
        {
            var result = await ApiClientService.GetAll();

            if(result.Succeeded)
            {
                clients = result.Value.ToList();
            }
        }


        private async Task SubmitShipment()
        {

            Shipment.Price = Shipment.Weight * 1 + (Shipment.DeliveryType == DeliveryType.ToOffice ? 8 : 10);
            Shipment.Status = ShipmentStatus.Registered;
            Shipment.RegisteredByEmployeeId = UserStateContainer.AccountId;
            
            try
            {
                IsSaving = true;
                var response = await ApiShipmentService.Create(Shipment);

                if (response.Succeeded)
                {
                    Snackbar.Add("Shipment created successfully!", Severity.Success);
                    Shipment = new(); // reset form
                }
                else
                {
                    Snackbar.Add("Failed to create shipment.", Severity.Error);
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add($"Error: {ex.Message}", Severity.Error);
            }
            finally
            {
                IsSaving = false;
            }
        }
        // Implementation will go here in the future
    }
}
