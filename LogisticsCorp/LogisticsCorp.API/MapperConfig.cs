namespace LogisticsCorp.API
{
    public static class MapperConfig
    {

        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Account, AccountDto>.NewConfig()
                .Include<Client, ClientDto>()
                    .MaxDepth(3)
                .Include<Employee, EmployeeDto>()
                    .MaxDepth(3);

            // Derived → Derived mappings
            TypeAdapterConfig<Client, ClientDto>.NewConfig()
                .MaxDepth(3);
            TypeAdapterConfig<Employee, EmployeeDto>.NewConfig()
                .MaxDepth(3);

            TypeAdapterConfig<Shipment, ShipmentDto>.NewConfig()
                .MaxDepth(4);

            TypeAdapterConfig<Office, OfficeDto>.NewConfig()
                .MaxDepth(4);

            TypeAdapterConfig<AccountDto, Account>.NewConfig()
                .Include<ClientDto, Client>()
                .Include<EmployeeDto, Employee>();
        }
    }
}