namespace LogisticsCorp.Web;

public static class MapperConfig
{
    public static void ConfigureMappings()
    {
        TypeAdapterConfig<AccountDto, AccountViewModel>.NewConfig()
            .Include<ClientDto, ClientViewModel>()
            .Include<EmployeeDto, EmployeeViewModel>();

        // Derived → Derived mappings
        TypeAdapterConfig<ClientDto, ClientViewModel>.NewConfig();
        TypeAdapterConfig<EmployeeDto, EmployeeViewModel>.NewConfig();

        TypeAdapterConfig<AccountViewModel, AccountDto>.NewConfig()
            .Include<ClientViewModel, ClientDto>()
            .Include<EmployeeViewModel, EmployeeDto>();
    }
}
