using Autobem.Domain.Entities;
using Autobem.Domain.Interfaces.Repositories;
using Autobem.Domain.Interfaces.Services;

namespace Autobem.Domain.Services
{
    public class ProprietarioService : BaseService<Proprietario>, IProprietarioService
    {
        private readonly IProprietarioRepository _repository;

        public ProprietarioService(IProprietarioRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
