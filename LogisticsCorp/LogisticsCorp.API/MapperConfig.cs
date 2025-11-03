using LogisticsCorp.Shared.Models.DTOs;
using System.Diagnostics;
using System.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LogisticsCorp.API
{
    public static class MapperConfig
    {

        public static void ConfigureMappings()
        {
            TypeAdapterConfig<Client, ClientDto>.NewConfig()
                .MaxDepth(3);
            TypeAdapterConfig<Account, AccountDto>.NewConfig()
                .MaxDepth(3);
            //TypeAdapterConfig<Class, ClassDto>.NewConfig()
            //    .MaxDepth(3);
            //TypeAdapterConfig<Grade, GradeDto>.NewConfig()
            //    .MaxDepth(3);
            //TypeAdapterConfig<Headmaster, HeadmasterDto>.NewConfig()
            //    .MaxDepth(3);
            //TypeAdapterConfig<Parent, ParentDto>.NewConfig()
            //    .MaxDepth(3);
            //TypeAdapterConfig<Profile, ProfileDto>.NewConfig()
            //    .MaxDepth(3);
            //TypeAdapterConfig<User, UserDto>.NewConfig()
            //    .MaxDepth(3);
        }
    }
}
