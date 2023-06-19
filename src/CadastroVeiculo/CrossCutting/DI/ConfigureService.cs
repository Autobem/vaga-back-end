using Domain.Dtos;
using Domain.Entidades;
using Microsoft.Extensions.DependencyInjection;
using Service.Interfaces;
using Service.Services;

namespace CrossCutting.DI
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProprietarioService, ProprietarioService>();
            serviceCollection.AddTransient<IVeiculoService, VeiculoService>();

            serviceCollection.AddAutoMapper(c =>
            {
                #region proprietario
                c.CreateMap<ProprietarioDto, Proprietario>();
                c.CreateMap<Proprietario, ProprietarioDto>();
                c.CreateMap<Proprietario, ProprietarioResponseDto>();
                c.CreateMap<ProprietarioUpdateDto, Proprietario>();
                #endregion

                #region Veiculo
                c.CreateMap<VeiculoDto, Veiculo>();
                c.CreateMap<Veiculo, VeiculoDto>();
                c.CreateMap<Veiculo, VeiculoResponseDto>();
                c.CreateMap<VeiculoUpdateDto, Veiculo>();
                #endregion
            });
        }
    }
}
