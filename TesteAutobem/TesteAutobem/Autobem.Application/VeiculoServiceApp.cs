using Autobem.Application.Interfaces;
using Autobem.Domain.Entities;
using Autobem.Domain.Interfaces.Services;

namespace Autobem.Application
{
    public class VeiculoServiceApp : BaseServiceApp<Veiculo>, IVeiculoServiceApp
    {
        private readonly IVeiculoService _service;

        public VeiculoServiceApp(IVeiculoService service) : base(service)
        {
            _service = service;
        }
    }
}
