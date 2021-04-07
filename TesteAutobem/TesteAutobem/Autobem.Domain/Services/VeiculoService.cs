using Autobem.Domain.Entities;
using Autobem.Domain.Interfaces.Repositories;
using Autobem.Domain.Interfaces.Services;

namespace Autobem.Domain.Services
{
    public class VeiculoService : BaseService<Veiculo>, IVeiculoService
    {
        private readonly IVeiculoRepository _repository;

        public VeiculoService(IVeiculoRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
