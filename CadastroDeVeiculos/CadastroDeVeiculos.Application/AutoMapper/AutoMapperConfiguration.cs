using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace CadastroDeVeiculos.Application.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Initialize()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                var profiles = Assembly.GetExecutingAssembly()
                .GetExportedTypes().Where(x => x.IsClass && typeof(Profile).IsAssignableFrom(x));

                foreach (var profile in profiles)
                {
                    cfg.AddProfile((Profile)Activator.CreateInstance(profile));
                }

            });

            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}
