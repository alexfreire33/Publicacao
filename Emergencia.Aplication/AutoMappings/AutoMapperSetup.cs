using AutoMapper;

namespace AI.Cadastro.API.AutoMapper
{
    public class AutoMapperSetup
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(autoMapperConfig =>
            {
                autoMapperConfig.AddProfile(new ClienteProfile());
          
            });
        }
    }
}